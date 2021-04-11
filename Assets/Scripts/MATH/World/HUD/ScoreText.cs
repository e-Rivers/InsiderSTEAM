using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    // Global attributes
    public static int scoreValue;
    public static Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        // Get component
        scoreText = GetComponent<Text>();
        // Set to 0 every time
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
            scoreText.text = scoreValue + " pts";
    }
}
