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
    private SpriteRenderer bg;
    private Text welcomeText;
    private Text introText;
    private GameObject introContainer;
    private Button startButton;
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
        // Get components
        bg = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        welcomeText = transform.GetChild(1).gameObject.GetComponent<Text>();
        introText = transform.GetChild(2).gameObject.GetComponent<Text>();
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
        // Set visual elements on
        bg.enabled = true;
        welcomeText.enabled = true;
        introText.enabled = true;
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
        // Let player grow
        PlayerAppearAnimation.instance.canGrow = true;
    }
}
