using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controla las animaciones del personajes
 * Autor: Carlos David Toapanta Noroña
 * Matrícula: A01657439
 */

public class ChangeAnimation : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Animator anim;
    private SpriteRenderer sprRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float velocidad = Mathf.Abs(rb2D.velocity.x);
        anim.SetFloat(name:"velocity", value: velocidad);

        // Left<->Right
        if (rb2D.velocity.x > 0.05)
        {
            sprRenderer.flipX = false;
        }
        else if (rb2D.velocity.x < -0.05)
        {
            sprRenderer.flipX = true;
        }

        /*// Idle <-> Jump
        if (!FloorTest.isInFloor)
        {
            anim.SetBool(name:"is_jumping", value:true);
        }
        else
        {
            anim.SetBool(name:"is_jumping", value:false);
        }
        */


    }
}
