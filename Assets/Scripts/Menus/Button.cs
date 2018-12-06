using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
///     Inherit from this to make other buttons.
///      Make sure to call Init at some point.
/// </summary>
public abstract class Button
    :
    MonoBehaviour
{
    /// <summary>
    ///     Takes a light that turns on when hovering over.
    /// </summary>
    /// <param name="lightName">Light tag string.</param>
    protected void Init( string lightName )
    {
        // Get box collider to check for mouse hovering.
        coll = GetComponent<BoxCollider2D>();
        Assert.IsNotNull( coll );

        // Use this to translate mouse position.
        cam = Camera.main;
        Assert.IsNotNull( cam );

        // Get custom light for this button to turn on/off
        //  when hovering.
        myLight = GameObject.FindGameObjectsWithTag( lightName )[0]
            .GetComponent<Light>();
        Assert.IsNotNull( myLight );
        UnHighlight();

        if( hover == null || click == null )
        {
            hover = gameObject.AddComponent<AudioSource>();
            click = gameObject.AddComponent<AudioSource>();

            hover.clip = cam.GetComponent<AudioHolder>().buttonHover;
            click.clip = cam.GetComponent<AudioHolder>().buttonClick;
        }
    }
    protected virtual void Update()
    {
        // Set up constraints and mouse position to check
        //  if we're hovering/clicking/etc.
        Vector2 min = ( Vector2 )coll.bounds.min;
        Vector2 max = ( Vector2 )coll.bounds.max;
        Vector2 mousePos = GetMousePos();

        // If mouse is within our box collider 2d.
        if( mousePos.x > min.x && mousePos.y > min.y &&
            mousePos.x < max.x && mousePos.y < max.y )
        {
            // Highlight when hovering.
            HighlightMe();

            // If hovering and clicking, but not clicking
            //  and dragging.
            if( Input.GetAxis( "Menu Click" ) > 0.0f &&
                canClick )
            {
                // This class doesn't use this, but the
                //  children do to implement their custom
                //  behavior.
                clicked = true;

                click.Play();
            }
            else clicked = false;
        }
        else UnHighlight(); // Make sure to unhighlight when mouse leaves.

        // canClick helps us make sure no clicking and
        //  dragging onto buttons causes us problems.
        if( Input.GetAxis( "Menu Click" ) > 0.0f ) canClick = false;
        else canClick = true;
    }
    protected void HighlightMe()
    {
        if( !hover.isPlaying ) hover.Play();
        // Turn the lights on.
        myLight.enabled = true;
    }
    protected void UnHighlight()
    {
        // Turn the lights off.
        myLight.enabled = false;
    }
    Vector2 GetMousePos()
    {
        // Typical method to get mouse position in pixel
        //  coordinates.
        Vector3 msPos = Input.mousePosition;
        return ( cam.ScreenToWorldPoint( msPos ) );
    }
    // 
    BoxCollider2D coll;
    Camera cam;
    protected Light myLight;
    protected bool clicked = false;
    bool canClick = false;
    static AudioSource hover = null;
    static AudioSource click = null;
}
