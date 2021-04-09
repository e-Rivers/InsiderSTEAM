using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingDestroyer : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D coll) {
        if (coll.gameObject.name == "CeilingDestroyer") {
            Destruction();
        }
    }

    void Destruction() {
        Destroy(this.gameObject);
    }
}
