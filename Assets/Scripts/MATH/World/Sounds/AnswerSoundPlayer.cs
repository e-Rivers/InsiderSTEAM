using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerSoundPlayer : MonoBehaviour
{
    // Sounds that are able to be played
    public static AnswerSoundPlayer instance;
    public AudioSource soundSource;
    public AudioClip[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        // Variable initalization
        instance = this;
    }

    // Play a sound
    public void Play(string soundType)
    {
        switch (soundType)
        {
            case "correct":
                soundSource.PlayOneShot(sounds[1]);
                break;
            case "incorrect":
                soundSource.PlayOneShot(sounds[2]);
                break;
            case "appear":
                soundSource.PlayOneShot(sounds[0]);
                break;
        }
    }
}
