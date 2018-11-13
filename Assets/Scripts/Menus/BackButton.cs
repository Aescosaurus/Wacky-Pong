using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BackButton
    :
    Button
{
    void Start()
    {
        base.Init( "BackLight" );
    }
    protected override void Update()
    {
        base.Update();

        // Destroy help menu and return to the main menu.
        if( clicked )
        {
            Destroy( GameObject
                .FindGameObjectsWithTag( "HelpMenu" )[0] );
        }
    }
}
