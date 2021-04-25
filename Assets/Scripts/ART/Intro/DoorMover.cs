using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMover : MonoBehaviour
{
    // Private attributes
    private float upperLim = 5.5f;
    private float lowerLim = 3.8f;
    private float speed = 0.004f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FloatingMovement");
    }

    // Routine to move gallery up n' down
    IEnumerator FloatingMovement()
    {
        // Repeat indefinitely
        while (true)
        {
            // Check for limits
            if (transform.position.y > upperLim)
            {
                speed = -0.004f;
            }
            if (transform.position.y < lowerLim)
            {
                speed = 0.004f;
            }
            // Alter limits
            transform.position += new Vector3(0f, speed, 0f);
            yield return null;
        }
    }

}
