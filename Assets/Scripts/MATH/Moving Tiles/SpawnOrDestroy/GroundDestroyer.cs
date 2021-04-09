using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour {
    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.name == "GroundDestroyer") {
            Destruction();
        }
    }

    void Destruction() {
        Destroy(this.gameObject);
    }

}
