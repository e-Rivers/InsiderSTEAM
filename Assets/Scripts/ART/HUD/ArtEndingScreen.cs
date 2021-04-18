using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtEndingScreen : MonoBehaviour
{
    // Public attributes
    public static ArtEndingScreen instance;
    public bool win;

    // Private attributes
    [SerializeField] Text endingText;
    [SerializeField] Text score;
    [SerializeField] Button finishBtn;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set defaults
        endingText.enabled = false;
        score.enabled = false;
        finishBtn.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = false;
        finishBtn.transform.gameObject.GetComponent<Image>().enabled = false;
        finishBtn.enabled = false;
    }

    public void SetEndingScreen()
    {
        endingText.enabled = true;
        score.enabled = true;
        finishBtn.transform.GetChild(0).gameObject.GetComponent<Text>().enabled = true;
        score.text = "Puntuacion total: " + ArtScoreSystem.score;
        finishBtn.transform.gameObject.GetComponent<Image>().enabled = true;
        finishBtn.enabled = true;
        ArtScoreSystem.score = 0;
    }
}
