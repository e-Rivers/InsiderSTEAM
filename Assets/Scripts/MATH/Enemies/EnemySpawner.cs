using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{ 
    // Self reference
    public static EnemySpawner instance;

    // Initial variables
    public float minTime = 1.0f;    // Minimum spawning time between monsters
    public float maxTime = 5.0f;    // Maximum spawning time between monsters
    public float spawnTime = 5.0f;  // Random time at which a monster should be invoked
    public float time = 0f;         // Current time
    public bool canSpawn = true;
    public GameObject[] enemies;    // Array of current existing enemies in the game

    // Private attributes
    private bool canAddDiff = true;

    // Start is called before first frame update
    private void Start()
    {
        // Set self reference
        instance = this;
        // Set initial values
        minTime = 1.0f;
        maxTime = 5.0f;
        spawnTime = 5.0f;
        time = 0f;
        canSpawn = true;
        canAddDiff = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if can invoke monters
        if (canSpawn)
        {
            time += Time.deltaTime;

            if (time >= spawnTime)
            {
                SpawnObject();
                SetRandomTime();
            }
        }
        // Check if player has killed 10 monsters
        if (KillsText.kills % 10 == 0 && KillsText.kills != 0 && canAddDiff && minTime > 0.2f && maxTime > 1.0f)
        {
            minTime -= 0.2f;
            maxTime -= 1.0f;
            canAddDiff = false;
        }
        // Reactivate canAddDiff boolean
        if (KillsText.kills % 10 != 0)
        {
            canAddDiff = true;
        }
    }

    // Spawn an object
    void SpawnObject()
    {
        time = 0f;
        int spawnIndex = (int)(Random.Range(0, enemies.Length));
        var enemy = Instantiate(enemies[spawnIndex], transform.position, enemies[spawnIndex].transform.localRotation);
        enemy.transform.parent = transform.parent;
    }

    // Set a random time for spawning
    void SetRandomTime()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }
}
