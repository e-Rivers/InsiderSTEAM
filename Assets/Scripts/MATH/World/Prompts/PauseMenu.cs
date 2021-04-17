using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Public self reference
    public static PauseMenu instance;
    public Image bg;
    public bool canPause;
    // Private attributes
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set private components
        canvas = GetComponent<Canvas>();
        // Set values
        canPause = false;
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            PauseGame();
        }
    }

    // Enable pause screen
    public void PauseGame()
    {
        // Set time scale
        Time.timeScale = 0f;
        // Set UI
        canvas.enabled = true;
        bg.enabled = true;
        MusicPlayer.instance.SetLowPass(true);
        GameObject.Find("BigEnemySoundSource").GetComponent<AudioLowPassFilter>().enabled = true;
        GameObject.Find("MediumEnemySoundSource").GetComponent<AudioLowPassFilter>().enabled = true;
        GameObject.Find("SmallEnemySoundSource").GetComponent<AudioLowPassFilter>().enabled = true;
    }

    // Disable pause screen
    public void UnpauseGame()
    {
        // Set time scale
        Time.timeScale = 1.0f;
        // Set UI
        bg.enabled = false;
        canvas.enabled = false;
        MusicPlayer.instance.SetLowPass(false);
        GameObject.Find("BigEnemySoundSource").GetComponent<AudioLowPassFilter>().enabled = false;
        GameObject.Find("MediumEnemySoundSource").GetComponent<AudioLowPassFilter>().enabled = false;
        GameObject.Find("SmallEnemySoundSource").GetComponent<AudioLowPassFilter>().enabled = false;
    }
}
