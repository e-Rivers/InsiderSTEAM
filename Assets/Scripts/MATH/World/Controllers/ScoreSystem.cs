using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    // Public self reference
    public static ScoreSystem instance;
    // Public attributes
    public float scoreTimer;
    public bool canScore;
    // Private attributes
    private float currTime;

    // Start is called before first frame update
    private void Start()
    {
        // Set self reference
        instance = this;
        // Set values
        scoreTimer = 12.0f;
        canScore = true;
        currTime = 0.0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (currTime < scoreTimer)
        {
            currTime += Time.deltaTime;
        } else
        {
            if (PlayerHP.instance.lives > 0)
            {
                ScoreText.scoreValue -= 100;
                currTime = 0.0f;
            }
        }
    }
}
