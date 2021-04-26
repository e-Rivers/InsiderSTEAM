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
        StartCoroutine("DisplayText");
    }

    // Coroutine to display text
    IEnumerator DisplayText()
    {
        while (warning.color.a < 1.0f)
        {
            warning.color += new Color(0f, 0f, 0f, 0.001f);
            yield return null;
        }
        StartCoroutine("DisappearText");
    }

    // Coroutine to stop displaying text
    IEnumerator DisappearText()
    {
        int counter = 0;
        while (warning.color.a > 0.001f)
        {
            if (counter < 1)
            {
                counter++;
                yield return new WaitForSeconds(6f);
            }
            else
            {
                warning.color -= new Color(0f, 0f, 0f, 0.001f);
                yield return null;
            }
        }
        warning.color = new Color(warning.color.a, warning.color.g, warning.color.b, 0f);
        StartCoroutine("GoToMainMenu");
    }

    // Coroutine to go to main menu
    IEnumerator GoToMainMenu()
    {
        int counter = 0;
        while (counter < 1)
        {
            counter++;
            yield return new WaitForSeconds(2f);
        }
        MenuManager.nextScene = "MainMenu";
        MenuManager.instance.EnterScene(false);
        yield return null;
    }
}
