using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryOnClick : MonoBehaviour
{
    // Public self reference
    public static RetryOnClick instance;
    // Public attributes
    public bool canReload;

    // Start is called before the first frame update
    void Start()
    {
        // Set public reference
        instance = this;
        // Set values
        canReload = true;
    }

    // Reloads scene
    public void ReloadScene(bool sendData)
    {
        if (canReload)
        {
            canReload = false;
            if (sendData)
            {
                StartCoroutine("SendData");
            }
            else
            {
                MenuManager.nextScene = "MathLevel";
                MenuManager.instance.EnterScene(false);
                Time.timeScale = 1.0f;
            }
        }
    }
    // Goes to main menu
    public void LoadMainMenu()
    {
        PauseMenu.instance.canPause = false;
        SendingDataPrompt.instance.SetPrompt(ScoreText.scoreValue, 5, "MainMenu");
    }

    // Coroutine to send information before restarting level
    IEnumerator SendData()
    {
        SendingDataPrompt.instance.SetPrompt(ScoreText.scoreValue, 5, "MathLevel");
        yield return new WaitForSeconds(2f);
        MenuManager.nextScene = "MathLevel";
        MenuManager.instance.EnterScene(false);
        Time.timeScale = 1.0f;
    }

}
