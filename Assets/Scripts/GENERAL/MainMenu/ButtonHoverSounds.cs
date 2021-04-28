using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHoverSounds : MonoBehaviour
{
    // Private attributes
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] AudioClip clickClip;
    [SerializeField] Image bg;

    // Play sound when pointer enters button
    public void PlayOnHover()
    {
        audioSource.PlayOneShot(clip);
    }

    // Play sound when pointer enters button
    public void PlayOnClick()
    {
        audioSource.PlayOneShot(clickClip);
    }

    // Open credits scene when Credits button is clicked
    public void OpenCredits()
    {
        StartCoroutine("OpenCreditsAnim");
    }
    public IEnumerator OpenCreditsAnim()
    {
        bg.enabled = true;
        while (bg.color.a < 1.0f)
        {
            bg.color += new Color(0f, 0f, 0f, 0.05f);
            yield return null;
        }
        MenuManager.nextScene = "Credits";
        MenuManager.instance.EnterScene(false);
    }
}
