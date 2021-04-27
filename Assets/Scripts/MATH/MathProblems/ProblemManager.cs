using UnityEngine;

public class ProblemManager : MonoBehaviour
{
    // Reference to self
    public static ProblemManager instance;

    // Public attributes
    public Problem[] problems;              // Array of all problems
    public int currProblem;                 // Current problem the player needs to solve
    public float timePerProblem = 5.0f;     // Time allowed to answer each 
    public float remainingTime;             // Time remaining for the current problem
    public bool hasToAnswer = false;        // Lets player answer a question

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if timer has to run
        if (hasToAnswer)
        {
            Debug.Log("Time left: " + remainingTime);
            remainingTime -= Time.deltaTime;
        }
        else
        {
            remainingTime = timePerProblem;
        }

        // If the remaining time is over
        if (remainingTime <= 0.0f)
        {
            // Make tiles go up
            Incorrect();
        }
    }

    // Set a new problem
    public void SetProblem(int problem)
    {
        // Set new problem and reset timer
        currProblem = problem;
        remainingTime = timePerProblem;
        // Display on UI
        ProblemText.instance.SetProblemText(problems[currProblem]);
        // Play answering phase beginning sound
        AnswerSoundPlayer.instance.Play("appear");
    }

    // Call if player is correct
    public void Correct()
    {
        // Debug
        Debug.Log("Your answer was correct!");
        // Increase correct answers counter
        AnswerCounter.instance.correctAnswers++;
        // Empty UI
        ProblemText.instance.EmptyProblemText(true);
        // Make tiles go up
        MathTileManager.instance.Remove();
        // Add to score
        ScoreText.scoreValue += 1000;
        // Stop timer
        hasToAnswer = false;
        // Let player score again
        ScoreSystem.instance.canScore = true;
        // Play correct answer sound
        AnswerSoundPlayer.instance.Play("correct");
    }

    // Call if player is incorrect
    public void Incorrect()
    {
        // Debug
        Debug.Log("Your answer was incorrect!");
        // Empty UI
        ProblemText.instance.EmptyProblemText(false);
        // Make tiles go up
        MathTileManager.instance.Remove();
        // Add to score
        if (ScoreText.scoreValue >= 300)
        {
            ScoreText.scoreValue -= 300;
        }
        // Stop timer
        hasToAnswer = false;
        // Don't let player score
        ScoreSystem.instance.canScore = false;
        // Play incorrect answer sound
        AnswerSoundPlayer.instance.Play("incorrect");
    }

    // Receive answer
    public void ReceiveAnswer(int identifier)
    {
        // Check if answer is correct
        if (identifier == problems[currProblem].correctTile)
        {
            Correct();
        }
        else
        {
            Incorrect();
        }
        // Enable movement
        ProblemDisplayerMovement.instance.EnableMovement();
        // Reset timer
        remainingTime = timePerProblem;
    }
}
