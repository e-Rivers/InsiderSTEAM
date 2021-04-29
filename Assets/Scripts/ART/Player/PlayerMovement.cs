using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public static PlayerMovement instance;
    public float velocidadX = 10;     //Horizontal movement
    public bool disableInput = false;


    //Private 
    private Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize variables
        instance = this;
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        disableInput = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!disableInput)
        {
            //User input
            float movHorizontal = Input.GetAxis("Horizontal");  //En X
            animator.SetFloat("speed", movHorizontal);
            if (movHorizontal < 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
            //GameObject movement
            rb2d.velocity = new Vector2(movHorizontal * velocidadX, rb2d.velocity.y);
        }
    }
}
