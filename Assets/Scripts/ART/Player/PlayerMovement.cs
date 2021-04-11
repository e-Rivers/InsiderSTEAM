using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    public float velocidadX = 8;     //Horizontal movement

    
    //Private 
    private Rigidbody2D rb2d;

    
    // Start is called before the first frame update
    void Start()
    {
        //Initialize variables
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //User input
        float movHorizontal = Input.GetAxis("Horizontal");  //En X

        //GameObject movement
        rb2d.velocity = new Vector2(movHorizontal * velocidadX, rb2d.velocity.y );  

    }   
}
