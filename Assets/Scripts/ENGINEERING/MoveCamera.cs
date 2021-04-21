using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public GameObject personaje;

    void Update()
    {
        float x = Mathf.Clamp(personaje.transform.position.x, min:0, max:20);
        float y = Mathf.Clamp(personaje.transform.position.y, min: 0, max:4);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);
    }
}
