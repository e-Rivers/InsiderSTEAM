using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconTeleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll) {
        if (coll.CompareTag("Portal")) {
            
        }
    }
}
