using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class HelpButton 
    :
    Button
{
    void Start()
    {
        base.Init( "HelpLight" );
    }
    protected override void Update()
    {
        base.Update();

        // Create help menu if it hasn't been created yet.
        if( clicked && GameObject
            .FindGameObjectsWithTag( "HelpMenu" )
            .Length == 0 )
        {
            Instantiate( helpMenu );
        }
    }
    // 
    [SerializeField] GameObject helpMenu;
}
