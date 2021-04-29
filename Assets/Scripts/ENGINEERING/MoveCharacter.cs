using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controla el movimiento del personajes
 * Autor: Carlos David Toapanta Noro�a
 * Matr�cula: A01657439
 */
public class MoveCharacter : MonoBehaviour
{
    //Variables
    public static MoveCharacter instance;
    public float vX = 10;
    public float vY = 7;
    public float climbSpeed = 0.05f;
    public bool disableInput;
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody2D rb2d;

    //Metodos
    // Start is called before the first frame update
    void Start()
    {
        // Initialize self reference
        instance = this;
        //Inicializar variables
        rb2d = GetComponent<Rigidbody2D>();
        disableInput = true;
        // Start coroutine to enable player movement
        StartCoroutine("EnableMovement");
    }

    // Update is called once per frame
    void Update()
    {
        if (!disableInput)
        {
            inputHorizontal = Input.GetAxis("Horizontal");

            rb2d.velocity = new Vector2(inputHorizontal * vX, rb2d.velocity.y);
            inputVertical = Input.GetAxis("Vertical");

            if (inputVertical > 0 && FloorTest.isInFloor)
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, vY);
            }
        }
    }

    // Enable player movement
    IEnumerator EnableMovement()
    {
        yield return new WaitForSeconds(2f);
        disableInput = false;
    }
}
