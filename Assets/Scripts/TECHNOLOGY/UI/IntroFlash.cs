using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroFlash : MonoBehaviour
{
    // Private attributes
    private Image flash;
    // Start is called before the first frame update
    void Start()
    {
        flash = GetComponent<Image>();
        flash.color = new Color(1f, 1f, 1f, 1f);
        StartCoroutine("Flash");
    }

    // Flash animation
    IEnumerator Flash()
    {
        while (flash.color.a > 0)
        {
            flash.color -= new Color(0f, 0f, 0f, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
