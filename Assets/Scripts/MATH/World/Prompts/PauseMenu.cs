using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Public self reference
    public static PauseMenu instance;
    public bool canPause;
    // Private attributes
    private Canvas canvas;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set private components
        canvas = GetComponent<Canvas>();
        sprite = canvas.transform.GetChild(0).GetComponent<SpriteRenderer>();
        // Set values
        canPause = false;
        sprite.enabled = false;
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
        sprite.enabled = true;
        canvas.enabled = true;
        MusicPlayer.instance.SetLowPass(true);
    }

    // Disable pause screen
    public void UnpauseGame()
    {
        // Set time scale
        Time.timeScale = 1.0f;
        // Set UI
        sprite.enabled = false;
        canvas.enabled = false;
        MusicPlayer.instance.SetLowPass(false);
    }
}
