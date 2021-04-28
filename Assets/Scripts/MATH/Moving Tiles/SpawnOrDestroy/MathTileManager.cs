using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTileManager : MonoBehaviour
{
    // Public reference to self
    public static MathTileManager instance;
    // Public attributes
    public GameObject[] tiles;      // Tiles to be moved
    public bool canReceive = true;
    public bool canSpawn = true;

    // Private attributes
    private float[] answers;

    // Start is called before first frame update
    private void Start()
    {
        // Set self reference
        instance = this;
        // Set initial values
        canReceive = true;
        canSpawn = true;
    }

    // Update is called on every frame update
    private void Update()
    {
        // If player reaches 10 kills and it's the first time this condition is true
        if (KillsText.kills % 10 == 0 && KillsText.kills != 0 && canSpawn || Input.GetKeyDown(KeyCode.L))
        {
            // Make manager set a new problem
            ProblemManager.instance.SetProblem((int)Random.Range(0, ProblemManager.instance.problems.Length));
            // Get possible answers from current set problem
            answers = ProblemManager.instance.problems[ProblemManager.instance.currProblem].answers;
            // Spawn objects
            Spawn(answers);
            // Avoid multiple spawning
            canSpawn = false;
        }
        // If player hasn't reached another 10 kills
        if (KillsText.kills % 10 != 0)
        {
            canSpawn = true;
        }
    }

    // Spawn objects
    public void Spawn(float[] numbers)
    {
        // Counts how many iteration foreach has made
        int index = 0;
        // Call displayer
        ProblemDisplayerMovement.instance.Move(true);
        // Lets tiles send answers again
        canReceive = true;
        // Stop monsters from spawning
        EnemySpawner.instance.canSpawn = false;
        ForcefulKiller.instance.Enable();
        // Makes every tile child appear on screen
        foreach (GameObject tile in tiles)
        {
            // Set answer
            tile.GetComponent<MathTileOnShoot>().number = numbers[index];
            // Let tiles be shot
            tile.GetComponent<MathTileOnShoot>().isShot = false;
            // Reset animations
            tile.GetComponent<Animator>().ResetTrigger("Idle");
            tile.GetComponent<Animator>().SetTrigger("Idle");
            // Move tile down
            tile.GetComponent<MathTileMovement>().Move(false);
            // Increment counter
            index++;
        }
        // Let player answer
        ProblemManager.instance.hasToAnswer = true;
    }

    // Make tiles go up
    public void Remove()
    {
        // Enable enemy spawning
        EnemySpawner.instance.canSpawn = true;
        ForcefulKiller.instance.Disable();
        // Avoid multiple shooting
        SetCanBeShot(false);
        // Call displayer off the screen
        ProblemDisplayerMovement.instance.Move(false);
        // Makes every tile disappear from screen 
        foreach (GameObject tile in tiles)
        {
            // Set velocity
            tile.GetComponent<MathTileMovement>().Move(true);
        }
    }

    // Send answer to problemManager
    public void SendAnswer(int identifier)
    {
        // If tiles can send info
        if (canReceive)
        {
            // Send info
            ProblemManager.instance.ReceiveAnswer(identifier);
            // Stop tiles from sending info
            canReceive = false;
        }
    }

    // Set every tile's canBeShot boolean to whatever the received parameter says
    public void SetCanBeShot(bool canBeShot)
    {
        foreach (GameObject tile in tiles)
        {
            // Set boolean
            tile.GetComponent<MathTileOnShoot>().canBeShot = canBeShot;
        }
    }
}