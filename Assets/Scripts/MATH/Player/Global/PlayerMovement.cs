using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    public GameObject bouncingTile;         // Current tile the player is using to bounce
    public GameObject grabbedTile;          // Current tile the player is using to hang
    public float speed = 35.0f;             // Player's speed
    public float jumpForce = 30.0f;         // Player's double jump force
    public bool isGrounded = false;         // Checks if player is on the ground
    public bool canDoubleJump = false;       // Determines if player can make a double jump
    public bool canGrab = false;            // Determines if player can hang from a ceiling tile
    public bool disableXInput = true;      // Disables horizontal movement
    public bool inputEnabled = false;       // Disables all input

    private GameObject player;              // Self reference to player
    private Rigidbody2D rb2d;               // Self reference to Rigidbody2D
    private Animator anim;                  // Self reference to Animator
    private PlayerHP hpSystem;              // References player's healthSystem script
    private PlayerAim playerAim;            // References playerAim script
    private Animator ceilingAnimator;       // References the current ceilingTile's Animator
    private TileMover currClgBhvr;          // References the current tile's tileMover script
    private float bouncingForce;            // Gets the current bouncingTile's launch force
    private float hitTimer;            // Timer to avoid double bouncingTile impulse
    private float xMovement;                // Gets horizontal input values
    private bool isGrabbed = false;
    private bool reGrab = true;             // Lets player grab ceiling tiles again
    
    // Start function
    void Start() {
        // Initialize self reference
        instance = this;
        // Initialize components
        player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        hpSystem = GetComponent<PlayerHP>();
        playerAim = GetComponent<PlayerAim>();
        // Assign values to required components
        anim.SetBool("IsIdle", true);
        xMovement = 0.0f;
        // Player values
        isGrounded = false;
        isGrabbed = false;
        canDoubleJump = false;
        canGrab = false;
        disableXInput = true;
        inputEnabled = false;
        hitTimer = 0f;
        reGrab = true;
    }

    // Update is called once per frame
    void Update() {
        // Update horizontal input:
        if (!disableXInput)
        {
            xMovement = Input.GetAxis("Horizontal");
        } else {
            xMovement = 0.0f;
        }

        // Move in the input's direction
        if (inputEnabled)
        {
            Vector3 movement = new Vector3(xMovement, 0f, 0f);
            transform.position += movement * Time.deltaTime * speed;
        }

        // Animate left movement
        if (xMovement < 0) {
            anim.SetBool("IsRunning", true);
            GetComponent<SpriteRenderer>().flipX = true;
        }

        // Animate right movement
        if (xMovement > 0) {
            anim.SetBool("IsRunning", true);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        // Animate if idle
        if (xMovement == 0) {
            anim.SetBool("IsRunning", false);
        }

        // Animate if grabbing
        if (isGrabbed)
        {
            anim.SetBool("IsGrabbed", true);
        } else
        {
            anim.SetBool("IsGrabbed", false);
        }

        // Avoid double impulse by adding a bouncing retrigger delay
        hitTimer += Time.deltaTime;
        if (hitTimer >= 1.0) {
            isGrounded = false;
            reGrab = true;
            hitTimer = 0f;
        }

        // Double jump
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (canDoubleJump && inputEnabled)
            {
                rb2d.velocity = new Vector3(0f, 0f, 0f);
                rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                canDoubleJump = false;
            }
        }
        // Set grabbing variables
        if (!canGrab)
        {
            // Enable player movement again
            disableXInput = false;
            rb2d.constraints = RigidbodyConstraints2D.None;
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            // Detach player from parent
            player.transform.parent = null;
        }

        // Grab tile
        if (Input.GetKeyDown(KeyCode.E) && canGrab && inputEnabled)
        {
            // Set player animation
            isGrabbed = true;
            // If player is grabbing tile
            if (grabbedTile != null)
            {
                // Set transform parent
                player.transform.parent = grabbedTile.transform;
                // Set ceiling's isGrabbed bool to true
                currClgBhvr = grabbedTile.transform.parent.gameObject.GetComponent<TileMover>();
                currClgBhvr.isGrabbed = true;
                currClgBhvr.timesGrabbed++;
                // Animate current grabbed tile
                ceilingAnimator = grabbedTile.transform.parent.gameObject.GetComponent<Animator>();
                ceilingAnimator.ResetTrigger("isNotTouched");
                ceilingAnimator.SetTrigger("isTouched");
                // Check if player grabbed 2 healing tiles
                if (currClgBhvr.identifier == 8)
                {
                    hpSystem.grabbedHealingTiles++;
                }
                // Check if player grabbed a refill ceiling tile
                if (currClgBhvr.identifier == 6)
                {
                    if (currClgBhvr.timesGrabbed <= 1)
                    {
                        canDoubleJump = true;
                    }
                }
                // Check if player grabbed a killing enemy tile
                if (currClgBhvr.identifier == 7)
                {
                    currClgBhvr.Shoot();
                }
            }
            GetComponent<PlayerAim>().isGrabbing = true;
            // Limit player movement
            disableXInput = true;
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            playerAim.canShoot = false;            
        }
        // Let go of tile
        if (Input.GetKeyUp(KeyCode.E) && canGrab && inputEnabled)
        {
            // Add force towards ceiling tiles' direction
            rb2d.AddForce(new Vector3(-2.5f, 0, 0), ForceMode2D.Impulse);
            // Let player go of the tile
            ResetGrabbingVariables();
        }
    }

    public void ResetGrabbingVariables()
    {
        // Avoid regrabbing or sticking
        canGrab = false;
        reGrab = false;
        // Set ceiling's isGrabbed bool to false
        if (grabbedTile != null && currClgBhvr != null)
        {
            currClgBhvr.isGrabbed = false;
            // Reset ceilingTile animation parameter
            ceilingAnimator.ResetTrigger("isTouched");
            ceilingAnimator.SetTrigger("isNotTouched");
            // Reset player animation
            isGrabbed = false;
        } else
        {
            grabbedTile = null;
        }
        GetComponent<PlayerAim>().isGrabbing = false;   
    }

    // Player touches bouncepads or enemies
    void OnCollisionEnter2D (Collision2D coll) {
        // Check if the collision is a bouncing tile
        if (coll.gameObject.CompareTag("Bouncepad")) {
            // Conditional to avoid double impulses
            if (!isGrounded) {
                // Assign current bouncing tile
                bouncingTile = coll.gameObject;
                var bouncingTileMover = bouncingTile.GetComponent<TileMover>();
                bouncingForce = bouncingTileMover.bouncingForce;
                // Reset variables
                isGrounded = true;
                if (bouncingTileMover.identifier == 1)
                {
                    canDoubleJump = false;
                } else
                {
                    canDoubleJump = true;
                }
                // Bounce
                if (bouncingTileMover.identifier == 2 && bouncingTileMover.jumpedOnce)
                {
                    // Can't bounce again
                }
                else
                {
                    rb2d.AddForce(new Vector2(2.5f, bouncingForce), ForceMode2D.Impulse);
                    anim.ResetTrigger("Glide");
                    anim.SetTrigger("Jump");
                    bouncingTile.GetComponent<TileMover>().jumpedOnce = true;
                }
            }
        }
        // Check if collision is an enemy
        if (coll.gameObject.CompareTag("Enemy"))
        {
            Vector3 pushDirection = (transform.position - coll.gameObject.transform.position) * 2.5f;
            rb2d.AddForce(pushDirection, ForceMode2D.Impulse);
        }
    }


    // Detach from bouncing tiles
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bouncepad"))
        {
            bouncingTile = null;
        }
    }

    // Enable player canGrab bool
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ceiling") && reGrab)
        {
            canGrab = true;
        }
    }

    // Check if player can grab an upper tile
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ceiling") && reGrab)
        {
            // Assign potential grabbing tile
            grabbedTile = collision.gameObject;
        }
    }

    // Keep player from phantom-grabbing after dropping or ignoring a ceiling tile
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ceiling"))
        {
            ResetGrabbingVariables();
        }
    }
}
