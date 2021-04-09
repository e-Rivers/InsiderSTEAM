using UnityEngine;
using UnityEngine.UI;

public class TimerImage : MonoBehaviour
{
    // Public attributes
    public Image timerImage;
    public float timerRate;

    // Update is called once per frame
    void Update()
    {
        // Set timer rate
        timerRate = 1.0f / ProblemManager.instance.timePerProblem;
        // update the remaining time dial fill amount
        timerImage.fillAmount = timerRate * ProblemManager.instance.remainingTime;
    }
}
