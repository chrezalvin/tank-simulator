using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// must have audiosource component
[RequireComponent(typeof(AudioSource))]
public class ProgressivelySlower : MonoBehaviour
{
    public float startVolume = 1f;
    public float endVolume = 0.2f;
    public float durationSeconds = 3;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // progressively lower volume
        if (audioSource.volume > endVolume)
        {
            audioSource.volume -= startVolume * Time.deltaTime / durationSeconds;
        }

        if(Time.timeScale == 0)
        {
            audioSource.Pause();
        }
        else if (Time.timeScale == 1 && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }
}
