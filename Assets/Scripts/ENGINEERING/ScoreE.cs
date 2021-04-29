using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreE : MonoBehaviour
{
    private int finalScore;
    public GameObject display;
    public void FinalScore(int score)
    {
        finalScore = score * (100 / 5);
        display.GetComponent<Text>().text = finalScore + "pts";
    }
}
