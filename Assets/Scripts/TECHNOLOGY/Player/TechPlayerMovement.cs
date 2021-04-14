using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechPlayerMovement : MonoBehaviour
{
    // Public self reference
    public static TechPlayerMovement instance;
    // Public attributes
    public int x, y;
    public float speed;
    public float distancePerTap = 0.5f;

    // Private attributes
    private int playerY;
    private int yLimit, xLimit;
    private float tapTime = 0.15f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set attributes
        x = 0;
        y = 0;
        playerY = 14;
        xLimit = 15;
        yLimit = 15;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (x < xLimit - 1)
            {
                if (timer <= 0)
                {
                    transform.position += new Vector3(distancePerTap, 0, 0);
                    x++;
                    timer = tapTime;
                } else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (x > 0)
            {
                if (timer <= 0)
                {
                    transform.position += new Vector3(-distancePerTap, 0, 0);
                    x--;
                    timer = tapTime;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (playerY < yLimit - 1)
            {
                if (timer <= 0)
                {
                    transform.position += new Vector3(0, distancePerTap, 0);
                    playerY++;
                    y--;
                    timer = tapTime;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (playerY > 0)
            {
                if (timer <= 0)
                {
                    transform.position += new Vector3(0, -distancePerTap, 0);
                    playerY--;
                    y++;
                    timer = tapTime;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            timer = 0f;
        }
    }
}
