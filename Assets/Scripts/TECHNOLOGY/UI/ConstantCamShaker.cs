using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantCamShaker : MonoBehaviour
{
    // Private attributes
    private bool keepShaking;
    private float shakeTime;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        keepShaking = true;
        shakeTime = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter == 0)
        {
            StartCoroutine("ShakeCam");
            counter++;
        }
    }


    // Shake camera constantly
    IEnumerator ShakeCam()
    {
        while (keepShaking)
        {
            ArtCameraShake.instance.ShakeCamera(0.05f, shakeTime);
            yield return new WaitForSeconds(shakeTime);
        }
    }
}
