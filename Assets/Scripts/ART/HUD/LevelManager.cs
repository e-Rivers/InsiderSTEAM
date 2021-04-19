using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Public attributes
    public static LevelManager instance;
    public static int level;
    public static int levelsPlayed;

    public int maxLevels = 3;

    // Private attributes
    private static List<int> levels = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set button listener
        getNextLevel(false);
        levelsPlayed++;
    }

    public void getNextLevel(bool reload = true)
    {
        // Do only if number of played levels are less than 3
        if (levelsPlayed < maxLevels)
        {
            // Get a random new level number
            int rndLevel = Random.Range(0, 7);
            // If list of levels has less than 5 elements
            if (levels.Count < 7)
            {
                // Repeat
                while (true)
                {
                    // If picked level number has already been picked before
                    if (levels.Contains(rndLevel))
                    {
                        // Set a new level number
                        rndLevel = Random.Range(0, 7);
                        // Otherwise, add to level numbers List and set level
                    }
                    else
                    {
                        level = rndLevel;
                        levels.Add(rndLevel);
                        break;
                    }
                }
            }
            if (reload)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            levelsPlayed = 0;
            levels.Clear();
            if (SceneManager.GetActiveScene().name.Equals("ArtLevel"))
            {
                PaintingDisplayer.instance.DisableCanvas();
                ArtEndingScreen.instance.SetEndingScreen();
            }
        }
    }

    public void SendToMainMenu()
    {
        levelsPlayed = 0;
        level = 0;
        levels.Clear();
        MenuManager.nextScene = "MainMenu";
        MenuManager.instance.EnterScene();
    }

}
