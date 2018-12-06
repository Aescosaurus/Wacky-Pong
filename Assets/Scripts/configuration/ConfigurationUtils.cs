using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return( configData.PaddleMoveUnitsPerSecond ); }
    }
    /// <summary>
    ///     How fast the ball will be when it starts moving.
    /// </summary>
    public static float BallImpulseForce
    {
        get { return( configData.BallImpulseForce ); }
    }
    /// <summary>
    ///     How much score the ball will add when it hits the paddle.
    /// </summary>
    public static float BallHits
    {
        get { return( configData.BallHits ); }
    }
    /// <summary>
    ///     How long until the ball despawns if it is still on screen.
    /// </summary>
    public static float BallLifetime
    {
        get { return( configData.BallLifetime ); }
    }
    /// <summary>
    ///     How long it takes for the ball to respawn once destroyed.
    /// </summary>
    public static float BallSpawnTime
    {
        get { return( configData.BallSpawnTime ); }
    }
    /// <summary>
    ///     Minimum amount of time it takes to spawn another ball on the field when others are still active.
    /// </summary>
    public static float BallMinSpawnSecs
    {
        get { return( configData.BallMinSpawnSecs ); }
    }
    /// <summary>
    ///     Maximum amount of time it can take to spawn another ball while others are still active.
    /// </summary>
    public static float BallMaxSpawnSecs
    {
        get { return( configData.BallMaxSpawnSecs ); }
    }

    public static float BonusPoints
    {
        get { return( configData.BonusPoints ); }
    }

    public static float BonusHits
    {
        get { return( configData.BonusHits ); }
    }

    public static float StandardSpawnRate
    {
        get { return( configData.StandardSpawnRate ); }
    }

    public static float BonusSpawnRate
    {
        get { return( configData.BonusSpawnRate ); }
    }

    public static float FreezerSpawnRate
    {
        get { return( configData.FreezerSpawnRate ); }
    }

    public static float SpeedupSpawnRate
    {
        get { return( configData.SpeedupSpawnRate ); }
    }

    public static float FreezerDuration
    {
        get { return( configData.FreezerDuration ); }
    }

    public static float SpeedupDuration
    {
        get { return( configData.SpeedupDuration ); }
    }

    public static float PointsToWin
    {
        get { return( configData.PointsToWin ); }
    }

    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        configData = new ConfigurationData();
    }
    // These are my fields.
    static ConfigurationData configData;
}
