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
    public void SetPrompt(int s, int wI, string nS)
    {
    	score = s;
    	worldId = wI;
    	nextScene = nS;
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
            rect.localPosition += new Vector3(10f, 0f, 0f);
            yield return null;
        }
        PostScores.postRequest(score, worldId, nextScene);
    }

    // Coroutine to remove container from the screen
    IEnumerator RemoveContainer()
    {
        while (rect.localPosition.x > -1875)
        {
            rect.localPosition -= new Vector3(10f, 0f, 0f);
            yield return null;
        }
        canvas.enabled = false;
        // Makes the transtition to the corresponding scene
		MenuManager.nextScene = nextScene;
		MenuManager.instance.EnterScene(false);
    }

}
