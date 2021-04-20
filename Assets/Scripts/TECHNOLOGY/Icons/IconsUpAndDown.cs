using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconsUpAndDown : MonoBehaviour
{
    // Private attributes
    private float hoverTime;
    private float timer = 0.6f;
    private int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        hoverTime = Random.Range(0.5f, 0.9f);
        timer = Random.Range(0, hoverTime);
        StartCoroutine("Hover");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            StartCoroutine("Hover");
        }
    }

    // Move up and down
    IEnumerator Hover()
    {
        while (timer > 0)
        {
            timer -= 0.1f;
            transform.position += new Vector3(0f, 0.1f, 0f) * direction;
            yield return new WaitForSeconds(0.1f);
        }
        timer = 0.6f;
        direction *= -1;
    }
}
