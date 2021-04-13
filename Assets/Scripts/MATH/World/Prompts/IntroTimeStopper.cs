using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTimeStopper : MonoBehaviour
{
    // Public self reference
    public static IntroTimeStopper instance;
    // Public attributes
    public GameObject startButton;
    public GameObject canvas;

    // Private attributes
    private GameObject child;
    private SpriteRenderer sprite;
    private bool playedSoundOnce;
    private bool stoppedOnce;

    // Start is called before the first frame update
    void Start()
    {
        // Self reference
        instance = this;
        QualitySettings.vSyncCount = 2;
        // Add scenes to SceneManager
        Debug.Log(SceneManager.sceneCountInBuildSettings + " scenes in build.");
        // Button reference
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(RestartTime);
        // Get sprite renderer
        child = transform.parent.GetChild(1).gameObject;
        sprite = child.GetComponent<SpriteRenderer>();
        // Reset variables
        playedSoundOnce = false;
        // Set timescale to zero
        StopTime();
    }

    // Call to stop time
    public void StopTime()
    {
        // Stop time scale
        Time.timeScale = 0.0f;
        // Play song
        MusicPlayer.instance.SetLowPass(true);
        MusicPlayer.instance.PlaySong();
        // Set enemy sounds triggers off
        Debug.Log(EnemyControl.instance.enabled);
        EnemyControl.instance.canTriggerSounds = false;
    }

    // Restart time
    public void RestartTime()
    {
        // Set time scale to normal
        Time.timeScale = 1.0f;
        // Disable canvas
        canvas.GetComponent<Canvas>().enabled = false;
        sprite.enabled = false;
        // Enable HUD
        HUDDisplayManager.instance.EnableHUD();
        PauseMenu.instance.canPause = true;
        // Announce round start
        if (!playedSoundOnce)
        {
            AnnouncerVoice.instance.PlayRoundStart();
            playedSoundOnce = true;
        }
        // Disable low pass
        MusicPlayer.instance.SetLowPass(false);
        // Set enemy sounds triggers on
        EnemyControl.instance.canTriggerSounds = true;
    }
}
