using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Assertions;

/// <summary>
///     Handles events thrown by the ball and such.
/// </summary>
public static class EventManager
{
    static List<UnityAction<ScreenSide,int>> listeners =
        new List<UnityAction<ScreenSide,int>>();
    static List<UnityEvent<ScreenSide,int>> invokers =
        new List<UnityEvent<ScreenSide,int>>();
    /// <summary>
    ///     Add an invoker to the list.
    /// </summary>
    /// <param name="invoker">Invoker that will be added.</param>
    private static void AddInvoker( UnityEvent<ScreenSide,int> invoker )
    {
        invokers.Add( invoker );
        if( listeners.Count >= 1 &&
            Last( listeners ) != null )
        {
            Last( invokers ).AddListener( Last( listeners ) );
        }
    }
    /// <summary>
    ///     Add a listener to be invoked.
    /// </summary>
    /// <param name="listener">Listener to be added.</param>
    public static void AddListener( UnityAction<ScreenSide,int> listener )
    {
        listeners.Add( listener );
        if( invokers.Count >= 1 &&
            Last( invokers ) != null )
        {
            Last( invokers ).AddListener( listener );
        }
    }
    /// <summary>
    ///     Returns the last item in a list.
    /// </summary>
    /// <typeparam name="T">Type the list holds.</typeparam>
    /// <param name="items">
    /// List that you're getting
    ///  the last item of.
    ///  </param>
    /// <returns>The last item in the list.</returns>
    private static T Last<T>( List<T> items )
    {
        Assert.IsTrue( items.Count >= 1 ) ;
        return( items[items.Count - 1] );
    }
}
