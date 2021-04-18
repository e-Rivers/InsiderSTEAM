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
    private string[] messages = new string[] { "¡EXCELENTE!", "¡MUY BIEN!", "¡ENHORABUENA!", "¡PERFECTO!", "¡BIEN HECHO!", "¡GRANDIOSO!", "¡MUY BUEN TRABAJO!" };

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        title.enabled = false;
        description.enabled = false;
        score.enabled = false;
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
        title.enabled = true;
        description.enabled = true;
        score.enabled = true;
        bg.color = new Color(0, 0, 0, 0.7f);
        // Update elements
        if (LevelManager.levelsPlayed > 3)
        {
            title.text = "¡GANASTE!";
            endBtn.GetComponent<Button>().enabled = true;
            endBtn.GetComponent<Image>().enabled = true;
            endBtn.transform.GetChild(0).GetComponent<Text>().enabled = true;
            description.text = "Completaste " + LevelManager.levelsPlayed + " desafíos";
        }
        else
        {
            title.text = messages[Random.Range(0, messages.Length)];
            continueBtn.GetComponent<Button>().enabled = true;
            continueBtn.GetComponent<Image>().enabled = true;
            continueBtn.transform.GetChild(0).GetComponent<Text>().enabled = true;
            description.text = "Has completado " + LevelManager.levelsPlayed + " desafíos";
        }

    }
}
