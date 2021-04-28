using UnityEngine;
using UnityEngine.UI;

public class MathTileOnShoot : MonoBehaviour
{
    // Public attributes
    public int identifier = 0;
    public float number = 0;
    public bool canBeShot = false;
    public bool isShot = false;

    // Private attributes
    private Animator anim;
    private Transform child;
    private BoxCollider2D boxColl;
    private Text text;

    // Start is called before the first frame update
    void Awake()
    {
        // Get components
        anim = GetComponent<Animator>();
        boxColl = GetComponent<BoxCollider2D>();
        // Get child components
        child = transform.GetChild(0);
        text = child.GetComponentInChildren<Text>();
        // Set initial values
        canBeShot = false;
        isShot = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Assign displayed number
        text.text = number.ToString();
    }

    // Check for triggers
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If trigger is a bullet
        if (collision.CompareTag("PlayerBullet"))
        {
            // Check if tiles can be shot
            if (canBeShot)
            {
                // Start animation
                anim.ResetTrigger("isShot");
                anim.SetTrigger("isShot");
                // If hasn't already been shot
                if (!isShot)
                {
                    // Send info to script
                    Debug.Log("Player shot tile " + identifier);
                    MathTileManager.instance.SendAnswer(identifier);
                    // Disable boxCollider
                    boxColl.enabled = false;
                    // Make unable to call functions twice
                    isShot = true;
                }
                ProblemDisplayerMovement.instance.Move(false);
            }
        }
    }
}
