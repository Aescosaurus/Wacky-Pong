using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Rotates the meatball in cool ways.
/// </summary>
public class MeatballRotator
    :
    MonoBehaviour
{
    /// <summary>
    ///     Rotate a little bit every frame.
    /// </summary>
    void Update()
    {
        transform.Rotate( Vector3.left,rotSpeed.x *
            Time.deltaTime / dtDiv );
        transform.Rotate( Vector3.up,rotSpeed.y *
            Time.deltaTime / dtDiv );
    }
    // 
    [SerializeField] Vector2 rotSpeed;
    const float dtDiv = 0.01725644f;
}
