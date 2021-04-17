using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconMover : MonoBehaviour
{
    // Public attributes
    // Private attributes
    private float xSpeed;
    private float ySpeed;
    private float timer;
    private float switchYVelocityTimer;
    // Start is called before the first frame update
    void Start ()
    {
        xSpeed = Random.Range(0.5f, 3.5f);
        ySpeed = Random.Range(-8.0f, 8.0f);
        switchYVelocityTimer = Random.Range(0.15f, 8.5f);
    }

    // Update is called once per frame
    void Update ()
    {

        if (timer < switchYVelocityTimer) {
            timer += Time.deltaTime;
        } else {
            SwitchY();
            switchYVelocityTimer = Random.Range(0.15f, 8.5f);
            timer = 0.0f;
        }
        if (transform.position.y >= 7.0f) {
            SwitchY("down");
        }
        if (transform.position.y <= -19.0f) {
            SwitchY("up");
        }
        transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;
    }
 
    // Check for collision to switch velocity
    private void OnTriggerEnter2D (Collider2D coll) {
        if (coll.CompareTag("Portal")) {
            float lastYposition = transform.position.y;
            transform.position = new Vector3(-20, lastYposition, 0);
        }
    }

    // Function to switch Y velocity
    private void SwitchY(string dir="opp") {
        switch (dir) {
            case "opp":
                ySpeed *= Random.Range(-3.0f, -1.0f);
                break;
            case "up":
                ySpeed = Random.Range(1.0f, 5.6f);
                break;
            case "down":
                ySpeed = Random.Range(-6.1f, 5.7f);
                break;
        }
    }
}
