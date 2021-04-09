using UnityEngine;

public class ProblemDisplayerMovement : MonoBehaviour
{
    // Public self reference
    public static ProblemDisplayerMovement instance;
    // Private attributes
    private RectTransform tf;
    private bool stop = true;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Get components
        tf = GetComponent<RectTransform>();
        // Set initial values
        stop = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if enemy spawner is inactive
        if (!EnemySpawner.instance.canSpawn)
        {
            GoDown();
        } else
        {
            GoUp();
        }
    }

    // Check for triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LowerDisplayStopper") || collision.CompareTag("UpperDisplayStopper"))
        {
            stop = true;
        }
    }

    // Move down function
    void GoDown()
    {
        if (!stop)
        {
            tf.position += Vector3.down * 10.0f * Time.deltaTime;
        }
    }

    // Move up function
    void GoUp()
    {
        if (!stop)
        {
            tf.position += Vector3.up * 10.0f * Time.deltaTime;
        }
    }

    // Enable movement
    public void EnableMovement()
    {
        stop = false;
    }
}
