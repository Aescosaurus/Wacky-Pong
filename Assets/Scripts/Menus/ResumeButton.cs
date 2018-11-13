using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ResumeButton
    :
    Button
{
    void Start()
    {
        base.Init( "ResumeLight" );
    }
    protected override void Update()
    {
        base.Update();

        // Unpause game and destroy pause menu.
        if( clicked )
        {
            // Loop through paused things and make them move.
            foreach( GameObject ball in GameObject
                .FindGameObjectsWithTag( "Ball" ) )
            {
                Ball ballScr = ball.GetComponent<Ball>();
                ballScr.Unfreeze();
                ballScr.StartMoving();
            }
            foreach( GameObject paddle in GameObject
                .FindGameObjectsWithTag( "Player" ) )
            {
                paddle.GetComponent<Paddle>().Unpause();
            }

            Destroy( GameObject
                .FindGameObjectsWithTag( "PauseMenu" )[0] );
        }
    }
}
