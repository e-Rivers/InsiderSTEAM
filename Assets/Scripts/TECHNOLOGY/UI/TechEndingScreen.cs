/*
    This script's purpose is to let player know when they've got a correct answer by displaying a screen
    stating how many puzzles they have solved and their current score. Once the 'continue' button is clicked,
    the script will determine if a next level should be loaded or if the player has finished all three puzzles.

    Contributors: Raul Youthan Irigoyen Osorio
                  Diego Armando Ulibarri Hernández
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechEndingScreen : MonoBehaviour
{
    // Public attributes
    public static TechEndingScreen instance;
    // Private attributes
    [SerializeField] Text title;
    [SerializeField] Text description;
    [SerializeField] Text score;
    [SerializeField] GameObject endBtn;
    [SerializeField] GameObject continueBtn;
    [SerializeField] Image bg;
    [SerializeField] Text inGameScoreDisplay;
    [SerializeField] Text timeRemainingText;
    private string[] messages = new string[] { "¡EXCELENTE!", "¡MUY BIEN!", "¡ENHORABUENA!", "¡PERFECTO!", "¡BIEN HECHO!", "¡GRANDIOSO!", "¡MUY BUEN TRABAJO!" };

    // Start is called before the first frame update
    void Start()
    {
        // Always start with timeScale set to 1.0
        Time.timeScale = 1.0f;
        // Set self reference
        instance = this;
        // Disable winning screen elements
        title.enabled = false;
        description.enabled = false;
        score.enabled = false;
        inGameScoreDisplay.enabled = true;
        timeRemainingText.enabled = true;
        bg.enabled = false;
        // Get buttons' components
        continueBtn.GetComponent<Image>().enabled = false;
        continueBtn.GetComponent<Button>().enabled = false;
        continueBtn.transform.GetChild(0).GetComponent<Text>().enabled = false;
        endBtn.GetComponent<Image>().enabled = false;
        endBtn.GetComponent<Button>().enabled = false;
        endBtn.transform.GetChild(0).GetComponent<Text>().enabled = false;
    }

    // When called, activate winning screen's canvas elements
    public void SetScreen()
    {
        // Make elements visible
        Time.timeScale = 0f;
        inGameScoreDisplay.enabled = false;
        timeRemainingText.enabled = false;
        title.enabled = true;
        description.enabled = true;
        score.enabled = true;
        // Don't allow player to stop
        TechPauseMenu.instance.canPause = false;
        // Display current score
        score.text += " " + TechScoreSystem.instance.GetLevelScore() + " pts.";
        // Make a darker background for the screen to be more clearly visible
        bg.enabled = true;
        bg.color = new Color(0, 0, 0, 0.7f);

        // If the player has completed three puzzles
        if (LevelManager.levelsPlayed >= LevelManager.instance.maxLevels)
        {
            // Set elements to let player know he's won and he'll go back to the main menu
            title.text = "¡GANASTE!";
            endBtn.GetComponent<Button>().enabled = true;
            endBtn.GetComponent<Image>().enabled = true;
            endBtn.transform.GetChild(0).GetComponent<Text>().enabled = true;
            description.text = "Completaste los " + LevelManager.levelsPlayed + " desafios";
            // Reset static variables
            TechScoreSystem.score = 0;
            TechScoreSystem.mistakes = 0;
        }
        else
        {
            // Pick one of the level completion's messages and make elements visible
            title.text = messages[Random.Range(0, messages.Length)];
            continueBtn.GetComponent<Button>().enabled = true;
            continueBtn.GetComponent<Image>().enabled = true;
            continueBtn.transform.GetChild(0).GetComponent<Text>().enabled = true;
            description.text = "Has completado " + LevelManager.levelsPlayed;
            // Adjust grammar according to the number of puzzles completed
            if (LevelManager.levelsPlayed == 1)
            {
                description.text += " desafio";
            }
            else
            {
                description.text += " desafios";
            }
        }
    }
}
