using UnityEngine;
using UnityEngine.UI;

public class EndingActivator : MonoBehaviour
{
    // Public attributes
    public GameObject endingCanvas;

    // Private attributes
    private Canvas canvas;
    private Text titleText;
    private Text finalScore;
    private SpriteRenderer bg;

    // Start is called before first frame update
    private void Start()
    {
        // Get components
        canvas = endingCanvas.GetComponent<Canvas>();
        titleText = endingCanvas.transform.GetChild(3).GetComponent<Text>();
        finalScore = endingCanvas.transform.GetChild(4).GetComponent<Text>();
        bg = endingCanvas.transform.GetChild(1).GetComponent<SpriteRenderer>();
        // Set component values
        bg.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is out of lives
        if (PlayerHP.instance.lives <= 0)
        {
            if (AnswerCounter.instance.correctAnswers >= AnswerCounter.instance.correctThreshold)
            {
                SetCanvas(true);
            } else
            {
                SetCanvas(false);
            }
        } else
        {
            canvas.enabled = false;
        }
    }

    // Adjust text
    void SetCanvas(bool won)
    {
        Debug.Log("Ended with " + AnswerCounter.instance.correctAnswers + " correct answers. (Won: " + won + ")");
        // Activate canvas containing victory info
        canvas.enabled = true;
        // Activate background
        bg.enabled = true;
        // Don't let player pause
        PauseMenu.instance.canPause = false;
        // If player won
        if (won)
        {
            // Remove enemies and projectiles from scene
            ForcefulKiller.instance.Enable();
            // Set title text
            titleText.text = "¡GANASTE!";
        } else
        {
            titleText.text = "¡PERDISTE!";
        }
        // Display score
        finalScore.text = "Puntuación final: " + ScoreText.scoreValue.ToString() + " pts";
        // Avoid scoring off-game
        ScoreSystem.instance.canScore = false;
        // Disable HUD
        HUDDisplayManager.instance.DisableHUD();
        // Enable scene reloading
        RetryOnClick.instance.canReload = true;
        // End music
        MusicPlayer.instance.EndSong();
        // Make slow-mo effect
        Time.timeScale = 0.4f;
    }
}
