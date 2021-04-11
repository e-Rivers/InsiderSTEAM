using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpawn : MonoBehaviour
{
    // Public attributes
    public GameObject[] colors;
    public float spawningTime = 1.0f;
    public float minTime = 0.5f;
    public float maxTime = 3.0f;
    // Private attributes
    private float timer = 0.0f;

    // Start
    void Start() {
        spawningTime = Random.Range(minTime, maxTime);
    }


    // Update is called once per frame
    void Update()
    {
        if (timer < spawningTime) {
            timer += Time.deltaTime;
        } else {
            // Choose color
            int colorIndex = (int)Random.Range(0, colors.Length);
            GameObject color = colors[colorIndex];
            // Instantiate color
            GameObject colorInstance = Instantiate(color, transform.position, Quaternion.identity);
            colorInstance.transform.parent = transform.parent;
            // Reset timer
            timer = 0.0f;
            spawningTime = Random.Range(minTime, maxTime);
        }
    }
}
