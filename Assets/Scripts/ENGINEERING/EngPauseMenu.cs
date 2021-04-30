using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EngPauseMenu : MonoBehaviour
{
    // Public attributes
    public static EngPauseMenu instance;
    public bool canPause;

    // Private attributes
    [SerializeField] GameObject titleContainer;
    [SerializeField] GameObject buttonContainer;
    [SerializeField] Image background;
    private float rate;
    private bool isPaused;
    private RectTransform titleTf;
    private RectTransform buttonTf;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        Application.targetFrameRate = 60;
        instance = this;
        // Let player pause as default
        canPause = true;
        isPaused = false;
        // Set background default opacity and fading rate
        background.enabled = false;
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0f);
        rate = 0.7372549f / 70;
        // Get game objects' transforms
        titleTf = titleContainer.GetComponent<RectTransform>();
        buttonTf = buttonContainer.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPause)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused)
                {
                    MoveCharacter.instance.disableInput = false;
                    StopCoroutine("DisplayMenu");
                    StartCoroutine("RemoveMenu");
                    isPaused = false;
                }
                else
                {
                    MoveCharacter.instance.disableInput = true;
                    StopCoroutine("RemoveMenu");
                    StartCoroutine("DisplayMenu");
                    isPaused = true;
                }
            }
        }
    }

    // Go to tutorial
    public void GoToTutorial()
    {
        Application.OpenURL("http://18.116.123.111:8080/insider/Tutoriales");
    }

    // Restart level
    public void RestartLevel()
    {
        MenuManager.nextScene = SceneManager.GetActiveScene().name;
        MenuManager.instance.EnterScene(false);
    }

    // Go to main menu
    public void GoToMenu()
    {
        canPause = false;
        SendingDataPrompt.instance.SetPrompt(ScoreE.instance.finalScore, 3, "MainMenu");
    }

    // Show pause menu
    IEnumerator DisplayMenu()
    {
        background.enabled = true;
        while (titleTf.localPosition.x < 0)
        {
            titleTf.localPosition += new Vector3(20f, 0f, 0f);
            buttonTf.localPosition += new Vector3(0f, 20f, 0f);
            background.color += new Color(0f, 0f, 0f, rate);
            yield return null;
        }
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0.7372549f);
    }

    // Remove pause menu
    IEnumerator RemoveMenu()
    {
        while (titleTf.localPosition.x > -1400)
        {
            titleTf.localPosition -= new Vector3(20f, 0f, 0f);
            buttonTf.localPosition -= new Vector3(0f, 20f, 0f);
            background.color -= new Color(0f, 0f, 0f, rate);
            yield return null;
        }
        background.color = new Color(background.color.r, background.color.g, background.color.b, 0f);
        background.enabled = false;
    }
}
