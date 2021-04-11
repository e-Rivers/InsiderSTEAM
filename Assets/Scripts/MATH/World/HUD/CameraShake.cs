using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{

    private Transform tf;
    private Vector3 tfPos;
    private float shakeLength;
    private float shakeMagntitude;
    private float damp;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        tf = GetComponent<Transform>();
        // Set component values
        tfPos = tf.localPosition;
        // Set script values
        shakeLength = 0.0f;
        shakeMagntitude = 0.7f;
        damp = 1.0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (shakeLength > 0.0f)
        {
            tf.localPosition = tfPos + Random.insideUnitSphere * shakeMagntitude;
            shakeLength -= Time.fixedDeltaTime * damp;
        } else
        {
            shakeLength = 0.0f;
            tf.localPosition = tfPos;
        }
    }

    // Call to shake camera
    public void ShakeCamera(float magnitude=0.7f, float length=0.5f)
    {
        shakeMagntitude = magnitude;
        shakeLength = length;
    }
}
