using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        float x = Mathf.Clamp(player.transform.position.x, min:0, max:20);
        float y = Mathf.Clamp(player.transform.position.y, min: 0, max:10);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
