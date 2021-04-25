using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    // Private attributes
    private Transform tfm;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        tfm = GetComponent<Transform>();
        speed = 0.005f;
        StartCoroutine("MoveAround");
    }

    IEnumerator MoveAround()
    {
        while (true)
        {
            if (tfm.position.x < -12.3f)
            {
                speed = 0.005f;
            }
            if (tfm.position.x > 12.4f)
            {
                speed = -0.005f;
            }
            tfm.position += new Vector3(speed, 0f, 0f);
            yield return null;
        }
    }
}
