using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerMovement : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float speed = 30.0f;

    // Starting variables
    private void Start()
    {
        // Assign components
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Initiate velocity
        rb2d.velocity = new Vector2(0, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "UpperLimit")
        {
            speed = -30;
        }
        if (collision.gameObject.name == "LowerLimit")
        {
            speed = 30;
        }
    }
}
