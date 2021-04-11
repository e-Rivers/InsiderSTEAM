using UnityEngine;

public class TileSpawner : MonoBehaviour {

    public Transform spawnPosition;
    public GameObject[] spawnees;
    public int minSpawn = 0;
    public float spawnTime = 0.5f;
    private float time = 0.0f;
    private int randomIndex;

    // Update every frame
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time >= spawnTime)
        {
            randomIndex = (int)(Random.Range(minSpawn, spawnees.Length));
            SpawnObject(randomIndex);
        }
    }

    // Spawn the object and restart current time
    public void SpawnObject(int ind) {
        var spawnedObject = Instantiate(spawnees[ind], spawnPosition.position, spawnPosition.rotation);
        spawnedObject.transform.parent = transform.parent;
        time = 0.0f;
    }
}
