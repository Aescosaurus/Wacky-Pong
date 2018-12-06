using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu
    :
    Button
{
    void Start()
    {
        base.Init( "BackToMenuLight" );
    }
    protected override void Update()
    {
        base.Update();

        // Destroy help menu and return to the main menu.
        if( clicked )
        {
            Timer.UnpauseAll();
            SceneManager.LoadScene( "MainMenu" );
        }
    }
}
