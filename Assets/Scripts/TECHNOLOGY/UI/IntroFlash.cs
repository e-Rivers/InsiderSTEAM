/*
    This script takes an Image component and makes it lose it's transparency until it reaches 0.
    Used for 'flashy' animations between scenes.

    Contributor: Raúl Youthan Irigoyen Osorio
*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroFlash : MonoBehaviour
{
    // Private attributes
    [SerializeField] Image flash;        // Image component to be used as flash transition source

    // Start is called before the first frame update
    void Start()
    {
        // Get Image component
        flash = GetComponent<Image>();
        // Set image color to white
        flash.color = flash.color;
        // Set framerate
        Application.targetFrameRate = 60;
        // Start flash animation
        StartCoroutine("Flash");
    }

    // Flash animation
    IEnumerator Flash()
    {
        // Repeat until Image's transparency is 0
        while (flash.color.a > 0)
        {
            // Reduce Image's transparency by 0.1
            flash.color -= new Color(0f, 0f, 0f, 0.02f);
            yield return null;
        }
        flash.enabled = false;
    }
}
