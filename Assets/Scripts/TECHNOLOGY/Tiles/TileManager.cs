using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // Public attributes
    public static TileManager instance;
    public int currentLevel = 0;
    public int[][] winnerMatrix;
    public int[,] matrix = new int[15,15];

    // Start is called before the first frame update
    void Start()
    {
        // Debug
        Debug.Log("Created TileManager");
        // Set self reference
        instance = this;
        // Set current matrix
        matrix = new int[15,15];
        winnerMatrix = new int[15][];
        // Set winner matrix
        winnerMatrix[0] = new int[]{ 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 };
        winnerMatrix[1] = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
        winnerMatrix[2] = new int[]{ 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
        winnerMatrix[3] = new int[]{ 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
        winnerMatrix[4] = new int[]{ 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
        winnerMatrix[5] = new int[]{ 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
        winnerMatrix[6] = new int[]{ 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
        winnerMatrix[7] = new int[]{ 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0 };
        winnerMatrix[8] = new int[]{ 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 0 };
        winnerMatrix[9] = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 };
        winnerMatrix[10] = new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        winnerMatrix[11] = new int[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
        winnerMatrix[12] = new int[]{ 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1 };
        winnerMatrix[13] = new int[]{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
        winnerMatrix[14] = new int[]{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update matrix
    public void SetValueAt(int i, int j, int val)
    {
        matrix[j, i] = val;
    }

    // Check if matrices are equal
    public bool CheckWin()
    {
        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                Debug.Log(matrix[i, j] + ", " + winnerMatrix[i][j] + "at x: " + i + " and y: " + j);
                if (matrix[i, j] != winnerMatrix[i][j]) 
                {
                    return false;
                }
            }
        }
        return true;
    }
}
