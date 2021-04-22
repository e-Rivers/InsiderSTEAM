using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controla el movimiento del personajes
 * Autor: Carlos David Toapanta Noroña
 * Matrícula: A01657439
 */
public class MoveCharacter : MonoBehaviour
{
    //Variables
    public float velocidadX = 10;
    public float velocidadY = 8;
    
    private Rigidbody2D rigidbody;

    //Metodos
    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        

        rigidbody.velocity = new Vector2(movHorizontal*velocidadX,rigidbody.velocity.y);
        float movVertical = Input.GetAxis("Vertical");

        if (movVertical > 0 && FloorTest.isInFloor)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,velocidadY);
        }
    }
}
