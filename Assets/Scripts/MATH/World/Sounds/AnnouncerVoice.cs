using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncerVoice : MonoBehaviour
{
    // Public attributes
    public static AnnouncerVoice instance;
    public AudioSource audioSource;
    public AudioClip[] voices;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
    
    // PLay starting voice
    public void PlayRoundStart()
    {
        audioSource.PlayOneShot(voices[0]);
    }

    // PLay game over voice
    public void PlayGameOver()
    {
        audioSource.PlayOneShot(voices[1]);
    }

}
