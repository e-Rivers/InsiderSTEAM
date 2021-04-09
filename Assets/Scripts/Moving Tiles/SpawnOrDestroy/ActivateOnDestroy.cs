using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnDestroy : MonoBehaviour
{
    // Public attributes
    public GameObject player;

    // Activate player's horizontal input
    private void OnDestroy()
    {
        player.GetComponent<PlayerMovement>().inputEnabled = true;
    }
}
