using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSound : MonoBehaviour
{
    // Public attributes
    public AudioClip audioClip;
    // Private attributes
    private AudioSource soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GameObject.Find("MainSoundSource").GetComponent<AudioSource>();
    }
    
    public void PlayDisappearSound()
    {
        soundPlayer.PlayOneShot(audioClip);
    }

}
