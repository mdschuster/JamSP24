using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioObject : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (clip != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
