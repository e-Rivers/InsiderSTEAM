using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtCameraShake : MonoBehaviour
{
    public static ArtCameraShake instance;
    private Transform tf;
    private Vector3 tfPos;
    private float shakeLength;
    private float shakeMagntitude;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        instance = this;
        tf = GetComponent<Transform>();
        // Set component values
        tfPos = tf.localPosition;
        // Set script values
        shakeLength = 0.0f;
        shakeMagntitude = 0.7f;
    }

    // Call to adjust coroutine variables
    public void ShakeCamera(float magnitude = 0.7f, float length = 0.5f)
    {
        shakeMagntitude = magnitude;
        shakeLength = length;
        StartCoroutine("Shake");
    }

    // Shake camera
    IEnumerator Shake()
    {
        while (shakeLength > 0)
        {
            shakeLength -= 0.1f;
            tf.localPosition = tfPos + Random.insideUnitSphere * shakeMagntitude;
            yield return null;
        }
        shakeLength = 0f;
        tf.localPosition = tfPos;
    }
}
