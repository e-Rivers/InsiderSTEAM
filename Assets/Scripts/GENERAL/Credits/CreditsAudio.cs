using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAudio : MonoBehaviour
{
    // Private attributes
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioLowPassFilter lowPassFilter;
    private float lowPassRate = 22000 / 1000;
    private float volumeRate = 0.3f / 1000;

    // Start is called before the first frame update
    void Start()
    {
        // Set framerate
        Application.targetFrameRate = 60;
        // Set private variables
        audioSource.volume = 0.0f;
        lowPassFilter.enabled = true;
        lowPassFilter.cutoffFrequency = 10;
        StartCoroutine("IncreaseVolume");
    }

    // Coroutine to start enabling sound
    IEnumerator IncreaseVolume()
    {
        int counter = 0;
        while (lowPassFilter.cutoffFrequency < 22000)
        {
            audioSource.volume += volumeRate;
            lowPassFilter.cutoffFrequency += lowPassRate;
            yield return null;
        }
        while (counter == 0)
        {
            counter++;
            yield return new WaitForSeconds(55f);
        }
        while (lowPassFilter.cutoffFrequency > 20)
        {
            audioSource.volume -= volumeRate;
            lowPassFilter.cutoffFrequency -= lowPassRate;
            yield return null;
        }
        MenuManager.nextScene = "MainMenu";
        MenuManager.instance.EnterScene(false);
    }
}
