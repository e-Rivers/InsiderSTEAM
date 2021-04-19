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
    [SerializeField] RawImage bg;
    [SerializeField] Text inGameScoreDisplay;
    [SerializeField] Text timeRemainingText;
    private string[] messages = new string[] { "¡EXCELENTE!", "¡MUY BIEN!", "¡ENHORABUENA!", "¡PERFECTO!", "¡BIEN HECHO!", "¡GRANDIOSO!", "¡MUY BUEN TRABAJO!" };

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        instance = this;
        title.enabled = false;
        description.enabled = false;
        score.enabled = false;
        inGameScoreDisplay.enabled = true;
        timeRemainingText.enabled = true;
        continueBtn.GetComponent<Image>().enabled = false;
        continueBtn.GetComponent<Button>().enabled = false;
        continueBtn.transform.GetChild(0).GetComponent<Text>().enabled = false;
        endBtn.GetComponent<Image>().enabled = false;
        endBtn.GetComponent<Button>().enabled = false;
        endBtn.transform.GetChild(0).GetComponent<Text>().enabled = false;
    }

    public void SetScreen()
    {
        // Make elements visible
        Time.timeScale = 0f;
        inGameScoreDisplay.enabled = false;
        timeRemainingText.enabled = false;
        title.enabled = true;
        description.enabled = true;
        score.enabled = true;
        score.text += " " + TechScoreSystem.instance.GetLevelScore() + " pts.";
        bg.color = new Color(0, 0, 0, 0.7f);

        // Update elements
        if (LevelManager.levelsPlayed >= LevelManager.instance.maxLevels)
        {
            title.text = "¡GANASTE!";
            endBtn.GetComponent<Button>().enabled = true;
            endBtn.GetComponent<Image>().enabled = true;
            endBtn.transform.GetChild(0).GetComponent<Text>().enabled = true;
            description.text = "Completaste los " + LevelManager.levelsPlayed + " desafios";
            TechScoreSystem.score = 0;
            TechScoreSystem.mistakes = 0;
        }
        else
        {
            title.text = messages[Random.Range(0, messages.Length)];
            continueBtn.GetComponent<Button>().enabled = true;
            continueBtn.GetComponent<Image>().enabled = true;
            continueBtn.transform.GetChild(0).GetComponent<Text>().enabled = true;
            description.text = "Has completado " + LevelManager.levelsPlayed;
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
