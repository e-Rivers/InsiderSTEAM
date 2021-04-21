using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGridCreator : MonoBehaviour
{
    // Public attributes
    public static TileGridCreator instance;
    public GameObject[][] tileMatrix;
    public GameObject tile;
    public bool finishedGrid;

    // Private attributes
    private Vector3 currPos;
    private int columns = 15;
    private int rows = 15;
    private int counter = 0;
    private float initX, initY;
    private float spacing = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Created TileGridCreator");
        // Set initial static reference
        instance = this;
        // Set matrix
        tileMatrix = new GameObject[rows][];
        for (int i = 0; i < rows; i++)
        {
            tileMatrix[i] = new GameObject[columns];
        }
        // Set initial position for first prefab
        initX = 0.5f;
        initY = 1.5f;
        finishedGrid = false;
    }

    private void Update()
    {
        if (counter == 0)
        {
            // Instatiate gameObjects
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    // Set current position
                    currPos = new Vector3(initX + spacing * j, initY - spacing * i, 0.0f);
                    // Instantiate, set parent and set attributes
                    GameObject tileInstance = Instantiate(tile, currPos, Quaternion.identity);
                    TileModifier tileModifier = tileInstance.GetComponent<TileModifier>();
                    tileModifier.x = initX + spacing * j;
                    tileModifier.y = initY - spacing * i;
                    tileMatrix[j][i] = tileInstance;
                    tileInstance.transform.parent = transform;
                    // Fill TileManager jagged array
                    TileManager.instance.matrix[i][j] = 0;
                }
            }
            finishedGrid = true;
            counter++;
        }
    }
}
