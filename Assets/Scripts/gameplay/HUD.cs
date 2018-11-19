using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
///     Displays UI elements like score and number of hits.
/// </summary>
public class HUD
    :
    MonoBehaviour
{
    // Score stuff.
    [SerializeField] GameObject scoreHolder;
    static Text scoreText;
    static int leftScore = 0;
    static int rightScore = 0;

    // Hit number stuff.
    [SerializeField] GameObject leftHitsHolder;
    [SerializeField] GameObject rightHitsHolder;
    static Text leftHitsText;
    static Text rightHitsText;
    static int nLeftHits = 0;
    static int nRightHits = 0;
    /// <summary>
    ///     Initializes static members with SerializeFields.
    /// </summary>
    void Start()
    {
        scoreText = scoreHolder.GetComponent<Text>();

        leftHitsText = leftHitsHolder.GetComponent<Text>();
        rightHitsText = rightHitsHolder.GetComponent<Text>();

        EventManager.AddListener( AddScore );
        Ball.AddPointsAddedListener( AddScore );
        EventManager.AddListener( AddHits );
        Paddle.AddHitPaddleListener( AddHits );
    }
    /// <summary>
    ///     Used by others to add hits for each side.
    /// </summary>
    /// <param name="side">Which side gets the hit.</param>
    /// <param name="nHitsToAdd">How many hits they get, usually 1.</param>
    void AddHits( ScreenSide side,int nHitsToAdd )
    {
        if( side == ScreenSide.Left )
        {
            nLeftHits += nHitsToAdd;
            leftHitsText.text = "Hits: " + nLeftHits;
        }
        else if( side == ScreenSide.Right )
        {
            nRightHits += nHitsToAdd;
            rightHitsText.text = "Hits: " + nRightHits;
        }
    }
    /// <summary>
    ///     Give more score to each side, called by outside world.
    /// </summary>
    /// <param name="scoringSide">Which side **scores the point**.</param>
    /// <param name="amountAdded">How many points said side gains.</param>
    void AddScore( ScreenSide scoringSide,int amountAdded )
    {
        switch( scoringSide )
        {
            case ScreenSide.Left:
                leftScore += amountAdded;
                break;
            case ScreenSide.Right:
                rightScore += amountAdded;
                break;
        }
        scoreText.text = leftScore.ToString() + " - " + rightScore;
    }
}
