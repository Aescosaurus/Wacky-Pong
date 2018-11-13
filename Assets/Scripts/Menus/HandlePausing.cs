using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Attach to camera pls.
/// </summary>
public class HandlePausing
    :
    MonoBehaviour
{
    void Update()
    {
        // If pressing pause and the pause menu isn't
        //  already spawned, spawn it.
        if( Input.GetAxis( "Pause" ) > 0.0f && GameObject
            .FindGameObjectsWithTag( "PauseMenu" )
            .Length == 0 )
        {
            // Create the actual pause menu.  The prefab
            //  stores position so we don't have to move it.
            Instantiate( pauseMenu );

            // Loop through all moving things and stop them.
            foreach( GameObject ball in GameObject
                .FindGameObjectsWithTag( "Ball" ) )
            {
                ball.GetComponent<Ball>().Freeze();
            }
            foreach( GameObject paddle in GameObject
                .FindGameObjectsWithTag( "Player" ) )
            {
                paddle.GetComponent<Paddle>().Pause();
            }
        }
    }
    // 
    [SerializeField] GameObject pauseMenu;
}
