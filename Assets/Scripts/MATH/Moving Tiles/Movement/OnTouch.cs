using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouch : MonoBehaviour {

    private Animator anim;

    void Start () 
    {
        // Get animator from tile
        anim = GetComponent<Animator>();
    }

    // Check for collisions
    void OnCollisionEnter2D (Collision2D coll) {
        // Check if player is the collision
        if (coll.gameObject.name == "Player") 
        {
            // Stop base animation
            anim.ResetTrigger("isNotTouched");
            // Do blinking tile animation
            anim.SetTrigger("isTouched");
        }
    }
    // Check for collision exits
    void OnCollisionExit2D(Collision2D coll)
    {
        // Check if player is the collision
        if (coll.gameObject.name == "Player")
        {
            // Stop blinking animation
            anim.ResetTrigger("isTouched");
            // Go back to base animation
            anim.SetTrigger("isNotTouched");
        }
    }
}