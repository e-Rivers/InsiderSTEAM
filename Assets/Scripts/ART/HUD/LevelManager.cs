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
    public static int sameLevelCount = 0;
    public static int levelsPlayed = 1;
    public static bool isNewLevel = false;
    public int maxLevels = 3;

    // Private attributes
    private static List<int> levels = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // If this is the first time the level is played
        if (sameLevelCount == 0 && levelsPlayed == 1)
        {
            // Set a random level
            level = Random.Range(0, 7);
            // Avoid level repetition
            levels.Add(level);
        }
        // Increment number of times this level has been played
        sameLevelCount++;
        // If this is a new level 
        if (isNewLevel)
        {
            // If maximum number of levels hasn't been reached
            if (levelsPlayed < maxLevels)
            {
                // Get a random level number
                int rndLevel = Random.Range(0, 7);
                // If list of levels still has less than its maximum capacity
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
                        }
                        // Otherwise, add to level numbers List and set level
                        else
                        {
                            level = rndLevel;
                            levels.Add(rndLevel);
                            break;
                        }
                    }
                }
                // In case there are more than 7 levels in list
                else
                {
                    // Empty levels list
                    levels.Clear();
                    // Set a random level
                    level = Random.Range(0, 7);
                    // Avoid level repetition
                    levels.Add(level);
                }
            }
        }
        // Debug
        Debug.Log("Game: " + levelsPlayed + " Level: " + level);
    }

    // Go to next level
    public void GetNextLevel(bool addLevel)
    {
        // Reset time scale
        Time.timeScale = 1.0f;
        // Check if levelsPlayed counter should be incremented
        if (addLevel)
        {
            isNewLevel = true;
            levelsPlayed++;
            sameLevelCount = 0;
        }
        else
        {
            isNewLevel = false;
        }
        if (levelsPlayed > maxLevels)
        {
            if (SceneManager.GetActiveScene().name.Equals("ArtLevel"))
            {
                PaintingDisplayer.instance.DisableCanvas();
                ArtEndingScreen.instance.SetEndingScreen();
            }
            else
            {
                SendToMainMenu();
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void SendToMainMenu()
    {
        levelsPlayed = 1;
        levels.Clear();
        sameLevelCount = 0;
        Time.timeScale = 1.0f;
        MenuManager.nextScene = "MainMenu";
        MenuManager.instance.EnterScene();
    }

}
