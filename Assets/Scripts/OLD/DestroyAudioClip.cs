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
