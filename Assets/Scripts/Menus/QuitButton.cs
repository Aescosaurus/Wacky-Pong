using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class QuitButton
    :
    Button
{
    void Start()
    {
        base.Init( "QuitLight" );
    }
    protected override void Update()
    {
        base.Update();

        // Exit game when you click.
        if( clicked ) Application.Quit();
    }
}
