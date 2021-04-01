using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharMaze : MonoBehaviour {
	public float speedX = 5;
	public float speedY = 5;
	private Rigidbody2D rigidBody;
	
	void Start() {
        	rigidBody = GetComponent<Rigidbody2D>();
	}

	void Update() {
		if(ScienceGameLogic.roundType%2==0) {
			// Horizontal move detection
        		float moveHorizontal = Input.GetAxis("Horizontal");
		        rigidBody.velocity = new Vector2(moveHorizontal*speedX, rigidBody.velocity.y);
	        	// Vertical move detection
		        float moveVertically = Input.GetAxis("Vertical");
       			rigidBody.velocity = new Vector2(rigidBody.velocity.x, moveVertically*speedY);
		}
    	}
}

