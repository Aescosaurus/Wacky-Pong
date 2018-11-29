using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball spawner
/// </summary>
public class BallSpawner
    :
    MonoBehaviour
{
    [SerializeField] GameObject standardBall;
    [SerializeField] GameObject bonusBall;
    [SerializeField] GameObject freezerPickup;
    [SerializeField] GameObject speedupPickup;
    Timer tim = null;
    int ballQueue = 0;
    /// <summary>
    ///     Set up timer.
    /// </summary>
    void Start()
    {
        tim = gameObject.AddComponent<Timer>();
        tim.Duration = GetRandDuration();
        tim.Run();

        tim.AddListener( SpawnBallResetTimer );
        EventManager.AddListener( SpawnNewBall2 );
        Ball.AddPointsAddedListener( SpawnNewBall2 );
    }
    void Update()
    {
		// While there are still balls in the queue,
		//  try to spawn a new one.
        if( ballQueue > 0 ) SpawnNewBall();
    }
    /// <summary>
    ///     Spawns a new ball at start.
    /// </summary>
    public void SpawnNewBall()
    {
        // Since all balls will spawn in the center, the
        //  "spawn hitbox" will be the same for all of them.
        TwoVec2 bounds = Ball.GetDiagBounds();

        // If no overlap is occurring.
        if( !Physics2D.OverlapArea( bounds.first,bounds.sec ) )
        {
            // Create the ball object and put it in center.
            GameObject tempBall = MakeRandBall();
            tempBall.transform.position = Vector3.zero;

            // Take the ball out of the queue.
            --ballQueue;
        }
        else
        {
            // If you can't spawn the ball add it to the
            //  queue.
            ++ballQueue;
        }
    }
    float GetRandDuration()
    {
        return( Random.Range( ConfigurationUtils
            .BallMinSpawnSecs,ConfigurationUtils
            .BallMaxSpawnSecs ) );
    }
    void SpawnBallResetTimer()
    {
        // Reset timer duration to random number between
        //  min and max ball spawn time.
        tim.Duration = GetRandDuration();

        // Actually create the new ball.
        SpawnNewBall();
    }
    void SpawnNewBall2( ScreenSide useless,int fake )
    {
        SpawnNewBall();
    }
    GameObject MakeRandBall()
    {
        // Generate new random number each time or else
        //  the others might not be called.  Also go in
        //  reverse order so the lower chances can work.
        if( ( int )Random.Range( 0,100 ) <
            ConfigurationUtils.SpeedupSpawnRate )
        {
            return( Instantiate( speedupPickup ) );
        }
        else if( ( int )Random.Range( 0,100 ) <
            ConfigurationUtils.FreezerSpawnRate )
        {
            return( Instantiate( freezerPickup ) );
        }
        else if( ( int )Random.Range( 0,100 ) <
            ConfigurationUtils.BonusSpawnRate )
        {
            return( Instantiate( bonusBall ) );
        }
        else if( ( int )Random.Range( 0,100 ) <
            ConfigurationUtils.StandardSpawnRate )
        {
            return( Instantiate( standardBall ) );
        }
        else // This can happen but is very rare.
        {
            return( Instantiate( standardBall ) );
        }
    }
}
