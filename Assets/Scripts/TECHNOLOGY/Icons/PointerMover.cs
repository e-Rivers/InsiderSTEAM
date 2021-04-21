using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerMover : MonoBehaviour
{
    // Private attributes
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip pointerClickClip;
    private Vector3 destination;
    private float growTimer;
    private float xSpeed;
    private float ySpeed;
    private float timer;
    private float xTimer;
    private float switchYVelocityTimer;
    private float switchXVelocityTimer;
    private bool moveRandomly;
    private bool keepGuessing;
    // Start is called before the first frame update
    void Start()
    {
        growTimer = 0f;
        moveRandomly = true;
        keepGuessing = true;
        transform.position = new Vector3(Random.Range(-18, 31), Random.Range(-19, 6), 0);
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
        // If pointer is in a random movement state
        if (moveRandomly)
        {
            // If player clicks
            if (Input.GetMouseButtonDown(0))
            {
                // Get mouse position
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.transform.gameObject.name.Equals("Pointer"))
                    {
                        audioSource.PlayOneShot(pointerClickClip);
                        moveRandomly = false;
                        TechScoreSystem.score -= 1500;
                    }
                }
            }
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
        else
        {
            if (keepGuessing)
            {
                int randomXIndex = Random.Range(0, TileManager.instance.winnerMatrix.Length);
                int randomYIndex = Random.Range(0, TileManager.instance.winnerMatrix.Length);
                if (TileManager.instance.winnerMatrix[randomXIndex][randomYIndex] == 1)
                {
                    GameObject randomCorrectTile = TileGridCreator.instance.tileMatrix[randomYIndex][randomXIndex];
                    destination = randomCorrectTile.transform.position;
                    keepGuessing = false;
                }
            }
            else
            {
                GoToTile(destination);
            }
        }
    }

    // Go to correct tile
    private void GoToTile(Vector3 destPos)
    {
        // If pointer has reached tile's position
        if (transform.position.x < destPos.x + 0.1 && transform.position.x > destPos.x - 0.1 && transform.position.y < destPos.y + 0.1 && transform.position.y > destPos.y - 0.1)
        {
            // Do a click animation
            GrowAnimation();
        }
        //  If pointer hasn't reached tile yet
        else
        {
            // If pointer is at the left of the tile, move it to the right
            if (transform.position.x < destPos.x)
            {
                transform.position += new Vector3(8.0f, 0f, 0f) * Time.deltaTime;
            }
            // If pointer is at the right of the tile, move it to the left
            if (transform.position.x > destPos.x)
            {
                transform.position -= new Vector3(8.0f, 0f, 0f) * Time.deltaTime;
            }
            // If pointer is below the tile, move it up
            if (transform.position.y < destPos.y)
            {
                transform.position += new Vector3(0f, 8.0f, 0f) * Time.deltaTime;
            }
            // If pointer is above the tile, move it down
            if (transform.position.y > destPos.y)
            {
                transform.position -= new Vector3(0f, 8.0f, 0f) * Time.deltaTime;
            }
        }
    }

    // Do click animation
    public void GrowAnimation()
    {
        if (growTimer < 0.3f)
        {
            transform.localScale += new Vector3(1f, 1f, 0f) * Time.deltaTime;
        }
        else
        {
            if (growTimer < 0.6f)
            {
                transform.localScale -= new Vector3(1f, 1f, 0f) * Time.deltaTime;
            }
            else
            {
                moveRandomly = true;
                keepGuessing = true;
            }
        }
        if (!moveRandomly)
        {
            growTimer += Time.deltaTime;
        }
        else
        {
            growTimer = 0f;
        }
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
