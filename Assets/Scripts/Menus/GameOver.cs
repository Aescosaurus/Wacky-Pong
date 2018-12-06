using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver
    :
    MonoBehaviour
{
    void Start()
    {
        gameOver = gameObject.AddComponent<AudioSource>();
        gameOver.clip = Camera.main.GetComponent<AudioHolder>().gameOver;
    }
    public void EndGame( ScreenSide winner )
    {
        gameOver.Play();
        var paddles = GameObject.FindGameObjectsWithTag( "Player" );
        var balls = GameObject.FindGameObjectsWithTag( "Ball" );

        Timer.PauseAll();
        foreach( var pad in paddles )
        {
            pad.GetComponent<Paddle>().Pause();
        }
        foreach( var ball in balls )
        {
            ball.GetComponent<Ball>().Freeze();
        }

        switch( winner )
        {
            case ScreenSide.Left:
                Instantiate( player1Wins );
                break;
            case ScreenSide.Right:
                Instantiate( player2Wins );
                break;
        }
    }
    void FreezeGameObject( GameObject obj )
    {
        var body = obj.GetComponent<Rigidbody2D>();

        if( body != null )
        {
            body.constraints = RigidbodyConstraints2D.FreezePosition |
                RigidbodyConstraints2D.FreezeRotation;
        }
    }
    // 
    [SerializeField] GameObject player1Wins;
    [SerializeField] GameObject player2Wins;
    AudioSource gameOver;
}
