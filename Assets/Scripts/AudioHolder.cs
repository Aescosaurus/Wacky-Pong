using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHolder
    :
    MonoBehaviour
{
    [SerializeField] public AudioClip buttonHover;
    [SerializeField] public AudioClip buttonClick;
    [SerializeField] public AudioClip ballHit;
    [SerializeField] public AudioClip paddleHit;
    [SerializeField] public AudioClip spawnBall;
    [SerializeField] public AudioClip loseBall;
    [SerializeField] public AudioClip gameOver;
    [SerializeField] public AudioClip freeze;
    [SerializeField] public AudioClip speedup;
}
