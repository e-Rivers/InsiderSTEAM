using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearColors : MonoBehaviour
{

void start()
 {
        
 }
 
void OnCollisionEnter2D(Collision2D other)
 {
            if (other.gameObject.tag == "Player")
           {
                    Destroy(gameObject);
           }
 }

// Update is called once per frame

}
