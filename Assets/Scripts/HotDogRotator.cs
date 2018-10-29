using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///     Rotates hot dogs in cool way.
/// </summary>
public class HotDogRotator
    :
    MonoBehaviour
{
    // Rotate hot dog sideways every frame.
    void Update()
    {
        transform.Rotate( Vector3.up,rotSpeed *
            Time.deltaTime / dtDiv );
    }
    // 
    [SerializeField] float rotSpeed = 3.81f;
    const float dtDiv = 0.01725644f;
}
