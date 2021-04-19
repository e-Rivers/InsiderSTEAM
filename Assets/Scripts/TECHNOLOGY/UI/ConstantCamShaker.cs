using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantCamShaker : MonoBehaviour
{
    // Private attributes
    private bool keepShaking;
    private float shakeTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        keepShaking = true;
        shakeTime = 0.5f;
        timer = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (keepShaking)
        {
            if (timer < shakeTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                ArtCameraShake.instance.ShakeCamera(0.05f, shakeTime);
                timer = 0f;
            }
        }
    }
}
