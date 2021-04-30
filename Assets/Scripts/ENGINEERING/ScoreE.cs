using UnityEngine;
using UnityEngine.UI;

public class ScoreE : MonoBehaviour
{
    public static ScoreE instance;
    public int finalScore;
    public GameObject display;

    void Start()
    {
        instance = this;
        finalScore = 0;
    }

    public void DisplayFinalScore()
    {
        display.GetComponent<Text>().text = finalScore + " pts.";
        GeneralScore.totalScore += finalScore;
    }

    public void AddScore(int score, float time)
    {
        finalScore += score + (int)(score * 1 / time);
    }
}
