using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    // Private attributes
    private float xLimit;
    // Start is called before the first frame update
    void Start()
    {
        xLimit = 9.3f;
        transform.position = new Vector3(Random.Range(-xLimit, xLimit), 8.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Random.Range(-xLimit, xLimit), 8.0f, 0.0f);
    }
}
