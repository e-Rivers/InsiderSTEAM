using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthWarning : MonoBehaviour
{
    // Private attributes
    [SerializeField] Text warning;

    // Start is called before the first frame update
    void Start()
    {
        // Remove opacity from current text
        warning.color = warning.color - new Color(0f, 0f, 0f, 1f);
        Application.targetFrameRate = 60;
        StartCoroutine("DisplayText");
    }

    // Coroutine to display text
    IEnumerator DisplayText()
    {
        while (warning.color.a < 1.0f)
        {
            warning.color += new Color(0f, 0f, 0f, 0.005f);
            yield return null;
        }
        StartCoroutine("DisappearText");
    }

    // Coroutine to stop displaying text
    IEnumerator DisappearText()
    {
        int counter = 0;
        while (warning.color.a > 0.005f)
        {
            if (counter < 1)
            {
                counter++;
                yield return new WaitForSeconds(4f);
            }
            else
            {
                warning.color -= new Color(0f, 0f, 0f, 0.005f);
                yield return null;
            }
        }
        warning.color = new Color(warning.color.a, warning.color.g, warning.color.b, 0f);
        StartCoroutine("GoToLogin");
    }

    // Coroutine to go to login screen
    IEnumerator GoToLogin()
    {
        int counter = 0;
        while (counter < 1)
        {
            counter++;
            yield return new WaitForSeconds(2f);
        }
        MenuManager.nextScene = "LoginScreen";
        MenuManager.instance.EnterScene(false);
        yield return null;
    }
}
