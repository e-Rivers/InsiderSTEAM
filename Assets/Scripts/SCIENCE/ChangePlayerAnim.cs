using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerAnim : MonoBehaviour {
    private Animator animator;
    private Rigidbody2D rigidBody;
    private SpriteRenderer renderer;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
	rigidBody = GetComponent<Rigidbody2D>();
	renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() {
        animator.SetFloat("playerSpeedY", rigidBody.velocity.y);
	animator.SetFloat("playerSpeedX", Mathf.Abs(rigidBody.velocity.x));
	if(rigidBody.velocity.x < 0) {
	    renderer.flipX = true;
	} else {
	    renderer.flipX = false;
	}
    }
}
