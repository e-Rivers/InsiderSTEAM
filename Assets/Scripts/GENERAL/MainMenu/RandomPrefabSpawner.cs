using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabSpawner : MonoBehaviour
{
    // Public attributes
    public GameObject[] prefabs;
    public float minSpawnRate;
    public float maxSpawnRate;
    public float spawnRate;
    // Private attributes
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate) 
        {
            timer += Time.deltaTime;
        } else 
        {
            timer = 0.0f;
            spawnRate = Random.Range(minSpawnRate, maxSpawnRate);
            int index = Random.Range(0, prefabs.Length);
            GameObject prefab = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity);
            prefab.transform.parent = transform;
        }
    }
}
