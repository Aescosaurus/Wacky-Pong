using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class DestroyBallWhenInvisible
    :
    MonoBehaviour
{
    /// <summary>
    ///     Checks if it should spawn a new ball, does so if necessary.
    /// </summary>
    void OnBecameInvisible()
    {
        // Get an array of ball game objects.
        var balls = GameObject
            .FindGameObjectsWithTag( "Ball" );

        // Loop through them, have to do this since when
        //  you call Destroy() on a game object, it takes a
        //  frame to actually destroy it, so when a new
        //  ball is created there are actually 2 for 1 frame.
        foreach( var theBall in balls )
        {
            // Cache script because we can.
            var ballScr = theBall.GetComponent<Ball>();

            // If ball is on screen and not already marked to be destroyed.
            if( !IsOnScreen( theBall.transform.position ) &&
                !ballScr.IsDead() )
            {
                // Make new ball and destroy the old one.
                ballScr.DestroyAndMakeNewBall();

                // Actually give score.
                // HUD.AddScore( side,1 );
                ballScr.AddPoints();
            }
        }
    }
    /// <summary>
    ///     Checks whether or not position is on screen.
    /// </summary>
    /// <param name="pos">Position to test.</param>
    /// <returns>True if on screen, false if outside.</returns>
    bool IsOnScreen( Vector2 pos )
    {
        // It's not perfect, but for the majority of cases it works.
        return( pos.x > ScreenUtils.ScreenLeft &&
            pos.x < ScreenUtils.ScreenRight &&
            pos.y > ScreenUtils.ScreenBottom &&
            pos.y < ScreenUtils.ScreenTop );
    }
}
