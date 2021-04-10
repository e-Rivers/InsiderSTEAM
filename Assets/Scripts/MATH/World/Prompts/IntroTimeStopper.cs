using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    // Start is called before the first frame update
    void Start()
    {
        // Self reference
        instance = this;
        // Button reference
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(RestartTime);
        // Get sprite renderer
        child = transform.parent.GetChild(1).gameObject;
        sprite = child.GetComponent<SpriteRenderer>();
        // Set timescale to zero
        StopTime();
    }

    // Call to stop time
    public void StopTime()
    {
        // Stop time scale
        Time.timeScale = 0.0f;
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
    }
}