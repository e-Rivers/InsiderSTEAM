using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearAnimation : MonoBehaviour
{
    // Public self reference
    public static PlayerAppearAnimation instance;
    // Public attributes
    public bool canGrow = true;
    // Private attributes
    private float limit;
    private float rate;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Stop time scale
        Time.timeScale = 0.0f;
        // Set growing x limit
        limit = 0.6f;
        // Set growth rate
        rate = limit / 20;
        // Set scale to 0, 0, 1
        transform.localScale = new Vector3(0f, 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canGrow)
        {
            if (transform.localScale.x < limit)
            {
                transform.localScale += 20f * Time.deltaTime * new Vector3(rate, rate, 0f);
            }
            else
            {
                canGrow = false;
            }
        }
    }
}
