using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtScoreSystem : MonoBehaviour
{
    // Public attributes
    public static ArtScoreSystem instance;
    public static int score;
    // Private attributes
    [SerializeField] Text scoreDisplay;
    [SerializeField] Image multDisplay;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip correctColorClip;
    [SerializeField] AudioClip incorrectColorClip;
    private float pointTimer;
    private float multiplier;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        pointTimer = 20f;
        multiplier = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        multDisplay.fillAmount -= 1.0f / 20f * Time.deltaTime;
        scoreDisplay.text = score + " pts";
        if (pointTimer > 0f)
        {
            pointTimer -= Time.deltaTime;
        }
        else
        {
            pointTimer = 0f;
        }
    }

    // Get current multiplier
    public void AddPoints(bool correct)
    {
        if (correct)
        {
            multiplier = pointTimer / 10;
            score += 250 + (int)Mathf.Floor(multiplier * 250);
            audioSource.PlayOneShot(correctColorClip);
            multDisplay.fillAmount = 1.0f;
            pointTimer = 20f;
        }
        else
        {
            if (score > 200)
            {
                score -= 200;
            }
            else
            {
                score -= score;
            }
            audioSource.PlayOneShot(incorrectColorClip);
        }
    }
}
