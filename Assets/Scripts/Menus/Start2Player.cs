using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start2Player
    :
    Button
{
    void Start()
    {
        base.Init( "Start2PLight" );
    }
    protected override void Update()
    {
        base.Update();

        // Load 2 player scene.
        if( clicked )
        {
            SceneManager.LoadScene( "Gameplay" );
        }
    }
}
