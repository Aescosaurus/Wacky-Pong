using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton
    :
    Button{

    void Start()
    {
        base.Init( "BackToMenuLight" );
    }
    protected override void Update()
    {
        base.Update();

        // Change the scene when pressed.
        if( clicked )
        {
            SceneManager.LoadScene( "MainMenu" );
        }
    }
}
