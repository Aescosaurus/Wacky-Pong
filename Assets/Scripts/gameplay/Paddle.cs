using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A paddle that moves up and down I guess.
/// </summary>
public class Paddle
    :
    MonoBehaviour
{
    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        // Wanna get a copy, not a ref.
        var pos = transform.position;
        moveMeBB = new Vector3( pos.x,pos.y,pos.z );

        var box = GetComponent<BoxCollider2D>();
        halfHeight = box.size.y / 2.0f;
        halfWidth = box.size.x / 2.0f;

        speed = ConfigurationUtils.PaddleMoveUnitsPerSecond;

        frozenTimer = gameObject.AddComponent<Timer>();

        if( !initializedListeners )
        {
            EventManager.AddListener( Freeze );
            Pickup.AddFrozenListener( Freeze );
            initializedListeners = true;
        }
    }
    void Update()
    {
        if( frozenTimer.Finished )
        {
            Unpause();
        }
    }
    /// <summary>
    /// Fixed Update is called like 50 times a second.
    /// </summary>
    void FixedUpdate()
    {
        // Don't let the player move or do anything if paused.
        if( paused ) return;

        // Test for left or right side and act accordingly.
        switch( mySide )
        {
            case ScreenSide.Left:
                if( Input.GetAxis( "Left Paddle Up" ) > 0.0f )
                {
                    moveMeBB.y += speed * Time.deltaTime;
                }
                if( Input.GetAxis( "Left Paddle Down" ) > 0.0f )
                {
                    moveMeBB.y -= speed * Time.deltaTime;
                }
                break;
            case ScreenSide.Right:
                if( Input.GetAxis( "Right Paddle Up" ) > 0.0f )
                {
                    moveMeBB.y += speed * Time.deltaTime;
                }
                if( Input.GetAxis( "Right Paddle Down" ) > 0.0f )
                {
                    moveMeBB.y -= speed * Time.deltaTime;
                }
                break;
            default:
                print( "You will never get this!" );
                break;
        }

        // Make sure your don't go off screen.
        moveMeBB.y = FindClampedY( moveMeBB.y );

        // Actually apply the movement changes we made.
        body.MovePosition( moveMeBB );
    }
    /// <summary>
    ///     Gets the y so you don't fly off the screen.
    /// </summary>
    /// <returns>a float</returns>
    float FindClampedY( float possibleNewY )
    {
        // Set up initial vars.
        var sTop = ScreenUtils.ScreenTop;
        var sBot = ScreenUtils.ScreenBottom;
        float newPos = 0.0f;

        // Check for hitting top, bot, or neither.
        if( possibleNewY + halfHeight > sTop )
        { // Hitting your head on the roof.
            newPos = sTop - halfHeight;
        }
        else if( possibleNewY - halfHeight < sBot )
        { // If you land on the floor.
            newPos = sBot + halfHeight;
        }
        else
        { // You hit nothing so u stay in the same place.
            newPos = possibleNewY;
        }

        // Give back your new y position.
        return( newPos );
    }
    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D( Collision2D coll )
    {
        var pickupScr = coll.gameObject.GetComponent<Pickup>();
        if( coll.gameObject.tag == "Ball" && pickupScr != null )
        {
            pickupScr.InvokeEffect( mySide );
            Destroy( coll.gameObject );
        }

        if( IsHittingSide( coll ) && coll.gameObject.CompareTag( "Ball" ) )
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter =
                coll.transform.position.y - transform.position.y;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfHeight;
            float angleOffset = normalizedBallOffset * bounceAngleHalfRange;

            // angle modification is based on screen side
            float angle;
            if( mySide == ScreenSide.Left )
            {
                angle = angleOffset;
            }
            else
            {
                angle = ( float )( Mathf.PI - angleOffset );
            }
            Vector2 direction = new Vector2( Mathf.Cos( angle ),Mathf.Sin( angle ) );

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection( direction );

            // Increment hits
            // HUD.AddHits( mySide,ballScript.Hits );
            hitPaddle.Invoke( mySide,( int )ballScript.Hits );
        }
    }
    /// <summary>
    ///     Checks whether a collision occurs on side(true) or top(false).
    /// </summary>
    /// <param name="coll">Collision object to check side or not.</param>
    /// <returns>True if hitting the side, false if hitting top/bot/back.</returns>
    bool IsHittingSide( Collision2D coll )
    {
        // var hitPos = coll.GetContact( 0 ).point;
        // var myPos = transform.position;
        // return( hitPos.x - myPos.x < halfWidth + 0.05f );
        if( coll.contactCount > 1 )
        {
            if( Mathf.Abs( coll.GetContact( 0 ).point.x -
                coll.GetContact( 1 ).point.x ) < 0.05 )
            {
                return( true );
            }
            else return( false );
        }
        else
        {
            return ( true );
        }
    }
    /// <summary>
    ///     Pause so the controls don't work.
    /// </summary>
    public void Pause()
    {
        paused = true;
    }
    /// <summary>
    ///     Return control to the player.
    /// </summary>
    public void Unpause()
    {
        paused = false;
    }
    void FreezeForDuration( int duration )
    {
        frozenTimer.Duration = ConfigurationUtils.FreezerDuration;
        frozenTimer.Run();
        Pause();
    }
    /// <summary>
    ///     Hooks up the listener to the invoker.
    /// </summary>
    /// <param name="listener">Listener to hook up.</param>
    public static void AddHitPaddleListener( UnityAction<ScreenSide,int> listener )
    {
        hitPaddle.AddListener( listener );
    }
    static void Freeze( ScreenSide s,int t )
    {
        var paddles = GameObject.FindGameObjectsWithTag( "Player" );
        var paddle1 = paddles[0].GetComponent<Paddle>();
        var paddle2 = paddles[1].GetComponent<Paddle>();
        if( paddle1.mySide != s )
        {
            paddle1.FreezeForDuration( t );
        }
        else
        {
            paddle2.FreezeForDuration( t );
        }
        // Pause();
        // Maybe change color to blue or cover in ice here.
    }
    // 
    Rigidbody2D body;
    [SerializeField] ScreenSide mySide;
    Vector2 moveMeBB;
    float speed;
    float halfHeight;
    float halfWidth;
    const float bounceAngleHalfRange = 60.0f * Mathf.Deg2Rad;
    bool paused = false;
    static BallLostEvent hitPaddle = new BallLostEvent();
    Timer frozenTimer;
    static bool initializedListeners = false;
}
