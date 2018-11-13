using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start1Player
    :
    Button
{
    void Start()
    {
        base.Init( "Start1PLight" );
    }
    protected override void Update()
    {
        base.Update();

        if( clicked )
        {
            print( "Start 1 player would happen now if it were implemented!" );
        }
    }
}
