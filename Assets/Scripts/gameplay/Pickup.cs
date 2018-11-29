using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pickup
    :
    Ball
{
    Timer despawnTimer;
    static FreezerActivatedEvent frozen = new FreezerActivatedEvent();
    // 
    protected override void Start()
    {
        base.Start();
    }
    // void Update()
    // {}
    // public void Spawn( Vector2 spawnPos,PickupType whichType )
    // {}
    public static void AddFrozenListener( UnityAction<ScreenSide,int> listener )
    {
        print( "Listener added!" );
        frozen.AddListener( listener );
    }
    public void InvokeEffect( ScreenSide side )
    {
        print( "Invoking freezer!" );
        print( side );
        print( base.GetBallType() );

        switch( base.GetBallType() )
        {
            case BallType.Freezer:
                frozen.Invoke( side,
                    ( int )ConfigurationUtils.FreezerDuration );
                break;
            case BallType.Speedup:
                break;
        }
    }
}
