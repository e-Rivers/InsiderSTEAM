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

    // Function to retry level
    public void Retry()
    {
        LevelManager.addLevel = false;
        LevelManager.instance.getNextLevel();
    }

    // Produce hover sounds
    public void OnHover()
    {
        audioSource.PlayOneShot(onHoverClip);
    }

}
