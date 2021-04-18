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
    public static bool ended = false;

    // Private attributes
    private static List<int> levels = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        // Set button listener
        getNextLevel(false);
    }

    public void getNextLevel(bool reload = true)
    {
        // Do only if number of played levels are less than 3
        if (levelsPlayed < 3)
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
        }
        else
        {
            endGame();
        }
        if (reload)
        {
            levelsPlayed++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void endGame()
    {
        Debug.Log("Ended game");
        levels.Clear();
        levelsPlayed = 0;
        ended = true;
    }

}