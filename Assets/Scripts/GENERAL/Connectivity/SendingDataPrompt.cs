using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SendingDataPrompt : MonoBehaviour
{
    // Private attributes
    [SerializeField] Canvas canvas;
    [SerializeField] RectTransform rect;
    public static SendingDataPrompt instance;

    private int score, worldId;
    private string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        canvas.enabled = false;
    }

    // Function to set prompt on screen
    public void SetPrompt(int scoreArg, int worldIdArg, string nextSceneArg)
    {
        score = scoreArg;
        worldId = worldIdArg;
        nextScene = nextSceneArg;
        StopCoroutine("RemoveContainer");
        StartCoroutine("SetContainer");
    }

    // Function to remove prompt from screen
    public void RemovePrompt()
    {
        StopCoroutine("SetContainer");
        StartCoroutine("RemoveContainer");
    }

    // Coroutine to move container inside the screen
    IEnumerator SetContainer()
    {
        canvas.enabled = true;
        while (rect.localPosition.x < -490)
        {
            rect.localPosition += new Vector3(50f, 0f, 0f);
            yield return null;
        }
        PostScores.postRequest(score, worldId, nextScene);
    }

    // Coroutine to remove container from the screen
    IEnumerator RemoveContainer()
    {
        yield return new WaitForSecondsRealtime(1f);
        while (rect.localPosition.x > -1875)
        {
            rect.localPosition -= new Vector3(50f, 0f, 0f);
            yield return null;
        }
        canvas.enabled = false;
        // Makes the transition to the corresponding scene
        MenuManager.nextScene = nextScene;
        if (nextScene == "MainMenu")
        {
            MenuManager.instance.EnterScene();
        }
        else if (!nextScene.Equals("ArtLevel") || !nextScene.Equals("TechLevel"))
        {
            LevelManager.levelsPlayed = 1;
            LevelManager.levels.Clear();
            LevelManager.sameLevelCount = 0;
            Time.timeScale = 1.0f;
            ArtScoreSystem.score = 0;
            TechScoreSystem.totalScore = 0;
            MenuManager.instance.EnterScene(false);
        }
        else
        {
            LevelManager.instance.GetNextLevel(false);
        }
    }

}
