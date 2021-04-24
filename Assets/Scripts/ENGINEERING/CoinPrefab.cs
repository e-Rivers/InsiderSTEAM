using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrefab : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
    	if(other.gameObject.CompareTag("Player")) {
    		GetComponent<SpriteRenderer>().enabled = false;
    		Destroy(gameObject, 0.3f);
    	}
    }
}
