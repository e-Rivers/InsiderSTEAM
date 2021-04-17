using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Public attributes
    public static MusicPlayer instance;
    public AudioSource audioSource;
    public AudioClip[] songs;

    // Private attributes
    private AudioLowPassFilter lowPass;
    private AudioReverbFilter reverbFilter;
    private float currVolume;

    // Start is called before the first frame update
    void Start()
    {
        // Assign components
        instance = this;
        lowPass = GetComponent<AudioLowPassFilter>();
        reverbFilter = GetComponent<AudioReverbFilter>();
        // Set component values
        lowPass.enabled = true;
        reverbFilter.enabled = false;
        currVolume = audioSource.volume;
        audioSource.volume = 0;
    }

    // Update is called on every frame update
    private void Update()
    {
        // Increase volume softly
        if (audioSource.volume < currVolume)
        {
            audioSource.volume += Time.deltaTime * 0.5f;
        }
    }


    // Play a song
    public void PlaySong()
    {
        audioSource.clip = songs[Random.Range(0, songs.Length)];
        audioSource.Play();
    }

    public void SetLowPass(bool onOff)
    {
        lowPass.enabled = onOff;
    }

    public void EndSong()
    {
        SetLowPass(true);
        reverbFilter.enabled = true;
    }
}
