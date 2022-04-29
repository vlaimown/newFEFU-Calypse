using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAudioClip : MonoBehaviour
{
    public AudioSource clip;

    private void Start()
    {
        clip = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (clip.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
