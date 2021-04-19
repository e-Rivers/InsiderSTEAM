using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColorChanger : MonoBehaviour
{
    // Private attributes
    private Text text;
    private float rate;
    private float timer;
    private float switchTime;
    // Start is called before the first frame update
    void Start()
    {
        rate = 0.3f;
        timer = 0.0f;
        switchTime = 2.0f;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < switchTime)
        {
            timer += Time.deltaTime;
            text.color += new Color(0f, rate, 0f, 0f) * Time.deltaTime;
        }
        else
        {
            timer = 0.0f;
            rate *= -1;
        }
    }
}
