using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Public attributes
    public static TileManager instance;
    public List<List<int>> winPatterns;
    public int currentLevel = 0;
    public int[][] winnerMatrix;
    public int[][] matrix;

    // Private attributes
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip patternClip;

    [SerializeField] AudioClip mistakeClip;
    [SerializeField] AudioClip winClip;
    // Start is called before the first frame update
    void Start()
    {
        // Debug
        Debug.Log("Created TileManager");
        // Set self reference
        instance = this;
        // Set current matrix
        matrix = new int[15][];
        // Initialize current matrix
        for (int i = 0; i < 15; i++)
        {
            matrix[i] = new int[15];
        }
        // Initialize winning matrix
        winnerMatrix = new int[15][];
        // Patterns to be checked in-game
        winPatterns = new List<List<int>>();
        // Set drawings to be accepted according to the current level's number
        switch (LevelManager.level)
        {
            case 0:
                winnerMatrix[0] = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
                winnerMatrix[1] = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
                winnerMatrix[2] = new int[] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
                winnerMatrix[3] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[4] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[5] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[6] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[7] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[8] = new int[] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
                winnerMatrix[9] = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
                winnerMatrix[10] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                winnerMatrix[11] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
                winnerMatrix[12] = new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1 };
                winnerMatrix[13] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
                winnerMatrix[14] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                break;
            case 1:
                winnerMatrix[0] = new int[] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[1] = new int[] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[2] = new int[] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[3] = new int[] { 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[4] = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[5] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
                winnerMatrix[6] = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[7] = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[8] = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[9] = new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[10] = new int[] { 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[11] = new int[] { 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[12] = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[13] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 };
                winnerMatrix[14] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1 };
                break;
            case 2:
                winnerMatrix[0] = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[1] = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1 };
                winnerMatrix[2] = new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 1, 0 };
                winnerMatrix[3] = new int[] { 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0 };
                winnerMatrix[4] = new int[] { 0, 0, 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[5] = new int[] { 0, 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[6] = new int[] { 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[7] = new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[8] = new int[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[9] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[10] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[11] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[12] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[13] = new int[] { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[14] = new int[] { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                break;
            case 3:
                winnerMatrix[0] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[1] = new int[] { 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0 };
                winnerMatrix[2] = new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0 };
                winnerMatrix[3] = new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
                winnerMatrix[4] = new int[] { 0, 0, 0, 1, 0, 0, 1, 1, 1, 0, 0, 1, 0, 0, 0 };
                winnerMatrix[5] = new int[] { 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0 };
                winnerMatrix[6] = new int[] { 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 0 };
                winnerMatrix[7] = new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 };
                winnerMatrix[8] = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
                winnerMatrix[9] = new int[] { 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 };
                winnerMatrix[10] = new int[] { 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0 };
                winnerMatrix[11] = new int[] { 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1 };
                winnerMatrix[12] = new int[] { 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0 };
                winnerMatrix[13] = new int[] { 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0 };
                winnerMatrix[14] = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 };
                break;
            case 4:
                winnerMatrix[0] = new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
                winnerMatrix[1] = new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
                winnerMatrix[2] = new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 };
                winnerMatrix[3] = new int[] { 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 };
                winnerMatrix[4] = new int[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 };
                winnerMatrix[5] = new int[] { 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 };
                winnerMatrix[6] = new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0 };
                winnerMatrix[7] = new int[] { 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0 };
                winnerMatrix[8] = new int[] { 0, 1, 1, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1, 1, 0 };
                winnerMatrix[9] = new int[] { 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1, 0 };
                winnerMatrix[10] = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 };
                winnerMatrix[11] = new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
                winnerMatrix[12] = new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
                winnerMatrix[13] = new int[] { 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0 };
                winnerMatrix[14] = new int[] { 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 1, 0, 0, 0, 0 };
                break;
            case 5:
                winnerMatrix[0] = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
                winnerMatrix[1] = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
                winnerMatrix[2] = new int[] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
                winnerMatrix[3] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[4] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[5] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[6] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[7] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[8] = new int[] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
                winnerMatrix[9] = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
                winnerMatrix[10] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                winnerMatrix[11] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
                winnerMatrix[12] = new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1 };
                winnerMatrix[13] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
                winnerMatrix[14] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                break;
            case 6:
                winnerMatrix[0] = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
                winnerMatrix[1] = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
                winnerMatrix[2] = new int[] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
                winnerMatrix[3] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[4] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[5] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[6] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[7] = new int[] { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
                winnerMatrix[8] = new int[] { 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
                winnerMatrix[9] = new int[] { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
                winnerMatrix[10] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                winnerMatrix[11] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
                winnerMatrix[12] = new int[] { 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1 };
                winnerMatrix[13] = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
                winnerMatrix[14] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                break;
        }
    }

    // Update matrix
    public void SetValueAt(int i, int j, int val)
    {
        matrix[j][i] = val;
    }

    // Check if matrices are equal
    public bool CheckWin()
    {
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                Debug.Log(matrix[i][j] + ", " + winnerMatrix[i][j] + "at x: " + i + " and y: " + j);
                if (matrix[i][j] != winnerMatrix[i][j])
                {
                    if (TechScoreSystem.mistakes < 3)
                    {
                        audioSource.PlayOneShot(mistakeClip);
                        TechScoreSystem.mistakes++;
                    }
                    ArtCameraShake.instance.ShakeCamera(0.3f, 0.3f);
                    return false;
                }
            }
        }
        audioSource.PlayOneShot(winClip);
        return true;
    }

    // Check if patterns from two matrices are the same
    public bool CheckComplete(int row, bool horizontal)
    {
        List<int> winCount = getPattern(winnerMatrix, row, horizontal);
        List<int> currCount = getPattern(matrix, row, horizontal);
        if (winCount.Count == currCount.Count)
        {
            for (int i = 0; i < winCount.Count; i++)
            {
                if (winCount[i] != currCount[i])
                {
                    return false;
                }
            }
            audioSource.PlayOneShot(patternClip);
            return true;
        }
        else
        {
            return false;
        }
    }

    // Generate pattern for a given row or column in a matrix
    public List<int> getPattern(int[][] mat, int row, bool horizontal)
    {
        // Temporary list to be added
        List<int> temp = new List<int>();
        // Ones counted before a new zero has been found
        int count = 0;
        // Iterate through given row
        for (int i = 0; i < mat.Length; i++)
        {
            // If we want to iterate through a row
            if (horizontal)
            {
                // If element in row is equal to zero
                if (mat[row][i] == 0)
                {
                    // If number of ones found are more than zero
                    if (count > 0)
                    {
                        // Add number of ones found to list and reset count
                        temp.Add(count);
                        count = 0;
                    }
                }
                // If element in row is other than zero
                else
                {
                    // Increase count
                    count++;
                }
            }
            // If we want to iterate through a column
            else
            {
                // If element in column is equal to zero
                if (mat[i][row] == 0)
                {
                    // If number of ones found are more than zero
                    if (count > 0)
                    {
                        // Add number of ones found to list and reset count
                        temp.Add(count);
                        count = 0;
                    }
                }
                // If element in column is other than zero
                else
                {
                    // Increase count
                    count++;
                }
            }
        }
        // If count is not zero after iteration
        if (count != 0)
        {
            // Add remainder to temporary list
            temp.Add(count);
        }
        return temp;
    }

}
