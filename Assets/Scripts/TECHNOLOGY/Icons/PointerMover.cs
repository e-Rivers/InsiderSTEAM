using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMover : MonoBehaviour
{
    private float xSpeed;
    private float ySpeed;
    private float timer;
    private float xTimer;
    private float switchYVelocityTimer;
    private float switchXVelocityTimer;
    // Start is called before the first frame update
    void Start()
    {
        xSpeed = Random.Range(-8.6f, 9.0f);
        ySpeed = Random.Range(-8.0f, 8.0f);
        switchYVelocityTimer = Random.Range(0.15f, 3.5f);
        switchXVelocityTimer = Random.Range(0.4f, 8.0f);
        timer = 0.0f;
        xTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer < switchYVelocityTimer)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SwitchY();
            switchYVelocityTimer = Random.Range(0.15f, 2.0f);
            timer = 0.0f;
        }
        if (xTimer < switchXVelocityTimer)
        {
            xTimer += Time.deltaTime;
        }
        else
        {
            SwitchX();
            switchXVelocityTimer = Random.Range(0.5f, 5.0f);
            xTimer = 0.0f;
        }
        if (transform.position.y >= 7.0f)
        {
            SwitchY("down");
        }
        if (transform.position.y <= -20.0f)
        {
            SwitchY("up");
        }
        transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime;
    }

    // Check for collision to switch velocity
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Portal"))
        {
            SwitchX("left");
        }
        if (coll.CompareTag("LeftPortal"))
        {
            SwitchX("right");
        }
    }

    // Function to switch Y velocity
    private void SwitchY(string dir = "opp")
    {
        switch (dir)
        {
            case "opp":
                ySpeed *= -1.0f;
                break;
            case "up":
                ySpeed = 8.0f;
                break;
            case "down":
                ySpeed = -7.7f;
                break;
        }
    }

    // Function to switch X velocity
    private void SwitchX(string dir = "opp")
    {
        switch (dir)
        {
            case "opp":
                xSpeed *= Random.Range(-2.5f, -0.9f);
                break;
            case "right":
                xSpeed = Random.Range(4.5f, 9.0f);
                break;
            case "left":
                xSpeed = Random.Range(-9.2f, -4.3f);
                break;
        }
    }
}
