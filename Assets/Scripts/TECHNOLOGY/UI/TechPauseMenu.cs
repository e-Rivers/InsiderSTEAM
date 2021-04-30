/*
    This script establishes TECH realm's pause menu behaviour (appearance, disappearance, and onClick 
    actions).

    Contributors: Diego Armando Ulibarri Hernández
                  Raúl Youthan Irigoyen Osorio

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class TechPauseMenu : MonoBehaviour
{
    // Public attributes
    public static TechPauseMenu instance;
    public bool canPause;

    // Pause menu elements
    [SerializeField] Image startMenu;
    [SerializeField] Button restartBtn;
    [SerializeField] Button tutorialBtn;
    [SerializeField] Button exitBtn;
    [SerializeField] AudioLowPassFilter audioLowPass;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip onHoverClip;
    [SerializeField] AudioClip onEnterClip;
    [SerializeField] AudioClip onExitClip;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize public variables
        instance = this;
        canPause = true;
        // Initialize paused state as false
        paused = false;
        // Disable menu elements from start
        audioLowPass.enabled = false;
        startMenu.enabled = false;
        restartBtn.GetComponent<Image>().enabled = false;
        restartBtn.enabled = false;
        tutorialBtn.GetComponent<Image>().enabled = false;
        tutorialBtn.enabled = false;
        exitBtn.GetComponent<Image>().enabled = false;
        exitBtn.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Detect user input
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if player is able to pause the game
            if (canPause)
            {
                Pause();
            }
        }
        // Detect user click on 'Inicio' button at the bottom of the screen
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse position
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.transform.gameObject.name.Equals("StartButton"))
                {
                    if (canPause)
                    {
                        Pause();
                    }
                }
            }
        }
    }

    // Function to retry level
    public void Retry()
    {
        LevelManager.instance.GetNextLevel(false);
    }

    // Produce hover sounds
    public void OnHover()
    {
        audioSource.PlayOneShot(onHoverClip);
    }

    // Open tutorial
    public void OpenTutorial()
    {
        Application.OpenURL("http://18.116.123.111:8080/insider/Tutoriales");
    }

    // Go to main menu
    public void GoToMenu()
    {
        canPause = false;
        Debug.Log(TechScoreSystem.totalScore);
        SendingDataPrompt.instance.SetPrompt(TechScoreSystem.totalScore, 2, "MainMenu");
        LevelManager.levelsPlayed = 1;
        TechScoreSystem.totalScore = 0;
    }

    // Activate pause menu
    void Pause()
    {
        if (!paused)
        {
            // Enable menu elements from start
            audioLowPass.enabled = true;
            startMenu.enabled = true;
            restartBtn.GetComponent<Image>().enabled = true;
            restartBtn.enabled = true;
            tutorialBtn.GetComponent<Image>().enabled = true;
            tutorialBtn.enabled = true;
            exitBtn.GetComponent<Image>().enabled = true;
            exitBtn.enabled = true;
            paused = true;
            audioSource.PlayOneShot(onEnterClip);
            // Enable player movement
            TechPlayerMovement.instance.enableMovement = false;
        }
        else
        {
            // Disable menu elements from start
            audioLowPass.enabled = false;
            startMenu.enabled = false;
            restartBtn.GetComponent<Image>().enabled = false;
            restartBtn.enabled = false;
            tutorialBtn.GetComponent<Image>().enabled = false;
            tutorialBtn.enabled = false;
            exitBtn.GetComponent<Image>().enabled = false;
            exitBtn.enabled = false;
            paused = false;
            audioSource.PlayOneShot(onExitClip);
            // Disable player movement
            TechPlayerMovement.instance.enableMovement = true;
        }
    }

}
