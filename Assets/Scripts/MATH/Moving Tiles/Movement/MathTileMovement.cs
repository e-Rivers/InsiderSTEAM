using UnityEngine;
using UnityEngine.UI;

public class MathTileMovement : MonoBehaviour
{
    // Public attributes
    public float speed = 15.0f;
    // Private attributes
    private Rigidbody2D rb2d;
    private BoxCollider2D boxColl;

    // Start is called before the first frame update
    void Awake()
    {
        // Get components
        rb2d = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();
    }

    // Check for triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If trigger is a tile stopper
        if (collision.CompareTag("UpperTileStopper") || collision.CompareTag("LowerTileStopper"))
        {
            // Stop any kind of movement
            rb2d.velocity = Vector3.zero;
            // Activate collisions
            boxColl.enabled = true;
            // Set hasToAnswer boolean to true
            if (collision.name == "TileLowerStopper")
            {
                ProblemManager.instance.hasToAnswer = true;
            }
        }
    }

    // If function is called, go up
    public void GoUp()
    {
<<<<<<< Updated upstream
        rb2d.velocity = Vector3.up * speed;
    }

=======
        while (tf.localPosition.y > -20)
        {
            tf.localPosition += new Vector3(0f, -0.3f, 0f);
            yield return null;
        }
        // Let player answer
        ProblemManager.instance.hasToAnswer = true;
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
>>>>>>> Stashed changes
}
