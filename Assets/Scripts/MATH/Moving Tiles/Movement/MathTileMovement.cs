using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MathTileMovement : MonoBehaviour
{
    // Public attributes
    public float speed = 15.0f;
    // Private attributes
    private Transform tf;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxColl;

    // Start is called before the first frame update
    void Awake()
    {
        // Get components
        tf = GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Enable tile movement
    public void Move(bool up)
    {
        if (up)
        {
            StopCoroutine("GoDown");
            StartCoroutine("GoUp");
        }
        else
        {
            StopCoroutine("GoUp");
            StartCoroutine("GoDown");
        }
    }

    // Move down function
    IEnumerator GoDown()
    {
        while (tf.localPosition.y > -20)
        {
            tf.localPosition += new Vector3(0f, -0.3f, 0f);
            yield return null;
        }
        MathTileManager.instance.SetCanBeShot(true);
    }

    // Move up function
    IEnumerator GoUp()
    {
        while (tf.localPosition.y < -4)
        {
            tf.localPosition += new Vector3(0f, 0.3f, 0f);
            yield return null;
        }
    }
    //
}
