using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroTimeStopper : MonoBehaviour
{
    // Public self reference
    public static IntroTimeStopper instance;
    // Private attributes
    [SerializeField] Image bg;
    private Canvas canvas;
    private bool playedSoundOnce;
    private bool stoppedOnce;
    private bool firstTime;

    // Start is called before the first frame update
    void Start()
    {
        // Self reference
        instance = this;
        firstTime = true;
        // Set scene to send after level ends
        MenuManager.nextScene = "MathRealm";
        // Set frame rate to 30 fps
        QualitySettings.vSyncCount = 2;
        // Reset variables
        playedSoundOnce = false;
        // Set components
        canvas = GetComponent<Canvas>();
    }

    void Update()
    {
        if (firstTime)
        {
            // Set timescale to zero
            StopTime();
            firstTime = false;
        }
    }

    // Call to stop time
    public void StopTime()
    {
        // Stop time scale
        Time.timeScale = 0.0f;
        // Set visual elements on
        bg.enabled = true;
        canvas.enabled = true;
        // Play song
        MusicPlayer.instance.SetLowPass(true);
        MusicPlayer.instance.PlaySong();
        // Set enemy sounds triggers off
        EnemyControl.instance.canTriggerSounds = false;
    }

    // Restart time
    public void RestartTime()
    {
        // Set time scale to normal
        Time.timeScale = 1.0f;
        // Set background off
        bg.enabled = false;
        canvas.enabled = false;
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
