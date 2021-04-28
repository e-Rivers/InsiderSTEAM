using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPanning : MonoBehaviour
{
    // Private attributes
    [SerializeField] GameObject bg;
    private float rate;

    // Start is called before the first frame update
    void Start()
    {
        rate = 0.0001f;
        StartCoroutine("PanImage");
    }

    // Coroutine to make image zoom in and out
    IEnumerator PanImage()
    {
        // Repeat indefinitely
        while (true)
        {
            // If maximum scale is reached
            if (bg.transform.localScale.x >= 2.0f)
            {
                rate = -0.0001f;
            }
            // If minimum scale is reached
            if (bg.transform.localScale.x <= 1.001f)
            {
                rate = 0.0001f;
                bg.transform.localScale = new Vector3(1.002f, 1.0002f, 1f);
            }
            bg.transform.localScale += new Vector3(rate, rate, 0f);
            yield return null;
        }
    }
}
