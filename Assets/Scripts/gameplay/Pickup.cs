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
    static FreezerActivatedEvent speedup = new FreezerActivatedEvent();
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
        frozen.AddListener( listener );
    }
    public static void AddSpeedupListener( UnityAction<ScreenSide,int> listener )
    {
        speedup.AddListener( listener );
    }
    public void InvokeEffect( ScreenSide side )
    {
        switch( base.GetBallType() )
        {
            case BallType.Freezer:
                frozen.Invoke( side,
                    ( int )ConfigurationUtils.FreezerDuration );
                break;
            case BallType.Speedup:
                speedup.Invoke( side,
                    ( int )ConfigurationUtils.SpeedupDuration );
                break;
        }
    }
}
