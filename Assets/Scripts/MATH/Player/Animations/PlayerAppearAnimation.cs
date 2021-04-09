using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAppearAnimation : MonoBehaviour
{
    // Public self reference
    public static PlayerAppearAnimation instance;
    // Public attributes

    // Private attributes
    private float limit;
    private float rate;
    private bool canGrow = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set growing x limit
        limit = transform.localScale.x;
        // Set growth rate
        canGrow = true;
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
                transform.localScale += new Vector3(rate, rate, 0f) * Time.deltaTime * 80.0f;
            }
            else
            {
                canGrow = false;
            }
        }
    }
}
