using System.Collections;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{

    public Transform spawnPosition;
    public GameObject[] spawnees;
    public int minSpawn = 0;
    public float spawnTime = 0.5f;
    private int randomIndex;

    // Start is called before first frame update
    private void Start()
    {
        StartCoroutine("spawnTiles");
    }

    // Spawn the object and restart current time
    public void SpawnObject(int ind)
    {
        var spawnedObject = Instantiate(spawnees[ind], spawnPosition.position, spawnPosition.rotation);
        spawnedObject.transform.parent = transform.parent;
    }

    IEnumerator spawnTiles()
    {
        while (true)
        {
            randomIndex = (int)(Random.Range(minSpawn, spawnees.Length));
            SpawnObject(randomIndex);
            yield return new WaitForSeconds(spawnTime);
        }
    }

}
