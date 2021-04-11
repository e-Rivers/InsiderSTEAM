using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSounds : MonoBehaviour
{
    // Public attributes
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        audioSource.PlayOneShot(audioClip);
    }

}
