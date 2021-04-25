using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButton : MonoBehaviour
{
    // Private atttibutes
    [SerializeField] Image textBox;
    [SerializeField] Text prompt;
    private Color originalTextBoxColor;
    private Color originalPromptColor;


    // Start is called before the first frame update
    void Start()
    {
        // Always disable these components when the scene has begun
        textBox.enabled = false;
        prompt.enabled = false;
        // Save original text and image color
        originalTextBoxColor = textBox.color;
        originalPromptColor = prompt.color;
    }

    // Call routine on hover
    public void OnHover()
    {
        StopCoroutine("RemoveBtnInfo");
        StartCoroutine("DisplayBtnInfo");
    }

    // Call routine when mouse isn't hovering anymore
    public void OffHover()
    {
        StopCoroutine("DisplayBtnInfo");
        StartCoroutine("RemoveBtnInfo");
    }

    // Show info about button whenever mouse is hovering over the button
    IEnumerator DisplayBtnInfo()
    {
        // Enable components
        textBox.enabled = true;
        prompt.enabled = true;
        // Start incrementing image's opacity
        while (textBox.color.a < 1.0f)
        {
            textBox.color += new Color(0f, 0f, 0f, 0.01f);
            prompt.color += new Color(0f, 0f, 0f, 0.01f);
            yield return null;
        }
    }

    // Remove info about button whenever mouse is hovering over the button
    IEnumerator RemoveBtnInfo()
    {
        // Start incrementing image's opacity
        while (textBox.color.a > 0.1f)
        {
            textBox.color -= new Color(0f, 0f, 0f, 0.1f);
            prompt.color -= new Color(0f, 0f, 0f, 0.1f);
            yield return null;
        }
        textBox.color = originalTextBoxColor;
        prompt.color = originalPromptColor;
        // Disable components
        textBox.enabled = false;
        prompt.enabled = false;
    }
}
