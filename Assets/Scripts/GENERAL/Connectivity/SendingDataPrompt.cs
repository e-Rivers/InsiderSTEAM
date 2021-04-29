using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendingDataPrompt : MonoBehaviour
{
    // Private attributes
    [SerializeField] Canvas canvas;
    [SerializeField] RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        canvas.enabled = false;
    }

    // Function to set prompt on screen
    public void SetPrompt()
    {
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
    }

}
