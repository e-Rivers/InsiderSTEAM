using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconSpawner : MonoBehaviour
{
    // Public attributes
    public GameObject[] icons;
    // Private attributes
    private Vector3 spawnPos;
    private int index = 0;
    private float spawnTime;
    private float timer;
    private float upperLimit;
    private float lowerLimit;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Random.Range(1.0f, 5.0f);
        upperLimit = 6.5f;
        lowerLimit = -17.0f;
        spawnPos = new Vector3(-20.0f, Random.Range(lowerLimit, upperLimit), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnTime) {
            timer += Time.deltaTime;
        } else {
            if (index < icons.Length) {
                GameObject icon = Instantiate(icons[index], spawnPos, Quaternion.identity);
                icon.transform.parent = transform;
                spawnPos = new Vector3(-20.0f, Random.Range(lowerLimit, upperLimit), 0f);
                index++;
                timer = 0f;
                spawnTime = Random.Range(1.0f, 5.0f);
            }
        }
    }
}
