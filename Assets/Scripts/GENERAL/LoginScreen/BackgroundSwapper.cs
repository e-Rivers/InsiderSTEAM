using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwapper : MonoBehaviour
{
    // Private attributes
    [SerializeField] Image bg_001;
    [SerializeField] Image bg_002;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        // Set counter
        counter = 0;
        // Set initial colors
        bg_001.color = new Color(bg_001.color.r, bg_001.color.g, bg_001.color.b, 1f);
        bg_002.color = new Color(bg_002.color.r, bg_002.color.g, bg_002.color.b, 0f);
        // Start swapping backgrounds
        StartCoroutine("SwapBackgrounds");
    }

    // Swap between backgrounds
    IEnumerator SwapBackgrounds()
    {
        while (true)
        {
            while (bg_001.color.a > 0.05f)
            {
                bg_001.color -= new Color(0f, 0f, 0f, 0.01f);
                bg_002.color += new Color(0f, 0f, 0f, 0.01f);
                yield return null;
            }
            bg_001.color = new Color(bg_001.color.r, bg_001.color.g, bg_001.color.b, 0f);
            bg_002.color = new Color(bg_002.color.r, bg_002.color.g, bg_002.color.b, 1f);
            yield return new WaitForSeconds(1f);
            while (bg_002.color.a > 0.05f)
            {
                bg_002.color -= new Color(0f, 0f, 0f, 0.01f);
                bg_001.color += new Color(0f, 0f, 0f, 0.01f);
                yield return null;
            }
            bg_001.color = new Color(bg_001.color.r, bg_001.color.g, bg_001.color.b, 1f);
            bg_002.color = new Color(bg_002.color.r, bg_002.color.g, bg_002.color.b, 0f);
            yield return new WaitForSeconds(1f);
        }
    }
}
