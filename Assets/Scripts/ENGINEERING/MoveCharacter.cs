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
    public float velocidadX = 10;
    public float velocidadY = 8;

    private Rigidbody2D rb2d;

    //Metodos
    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");


        rb2d.velocity = new Vector2(movHorizontal * velocidadX, rb2d.velocity.y);
        float movVertical = Input.GetAxis("Vertical");

        if (movVertical > 0 && FloorTest.isInFloor)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, velocidadY);
        }
    }
}
