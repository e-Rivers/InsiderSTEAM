using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyAdder : MonoBehaviour
{
    // Public attributes
    public GameObject[] spawners;
    public float difficultyAdderTime;

    // Private components
    private TileSpawner ceilingSpawner;
    private TileSpawner groundSpawner;
    private int timesDifficultyAdded = 0;
    private float difficultyTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        ceilingSpawner = spawners[0].GetComponent<TileSpawner>();
        groundSpawner = spawners[1].GetComponent<TileSpawner>();
        // Set values
        difficultyAdderTime = 10.0f;
        timesDifficultyAdded = 0;
        difficultyTimer = 0.0f;

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        difficultyTimer += Time.fixedDeltaTime;
        if (difficultyTimer >= difficultyAdderTime)
        {
            timesDifficultyAdded++;
            ceilingSpawner.spawnTime += 0.01f;
            groundSpawner.spawnTime += 0.01f;
            if (timesDifficultyAdded % 5 == 0 && timesDifficultyAdded <= 15 && timesDifficultyAdded != 0)
            {
                groundSpawner.minSpawn++;
            }
            difficultyTimer = 0.0f;
        }
    }
}
