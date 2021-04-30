using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngAnswerTimer : MonoBehaviour
{
    // Public attributes
    public static EngAnswerTimer instance;
    public float answerTimer;
    public float coinTimer;

    // Start is called before the first frame update
    void Start()
    {
        // Set framerate
        Application.targetFrameRate = 60;
        // Set self reference
        instance = this;
        // Set timers to default
        answerTimer = 0f;
        coinTimer = 0f;
        // Start coin timer
        StartCoroutine("CoinCountdown");
    }

    // Function called when player solves a puzzle correctly
    public void ResetAnswerTimer()
    {
        answerTimer = 0f;
        StopCoroutine("AnswerCountdown");
        StartCoroutine("AnswerCountdown");
    }

    // Function called when player grabs a coin
    public void ResetCoinTimer()
    {
        coinTimer = 0f;
        StopCoroutine("CoinCountdown");
        StartCoroutine("CoinCountdown");
    }

    // Coroutine to start decreasing answer timer
    IEnumerator AnswerCountdown()
    {
        while (answerTimer < 15.0f)
        {
            Debug.Log("Answer timer: " + answerTimer);
            answerTimer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }

    // Coroutine to start decreasing coin-grabbing timer
    IEnumerator CoinCountdown()
    {
        while (coinTimer < 3f)
        {
            Debug.Log("Coin timer: " + coinTimer);
            coinTimer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
