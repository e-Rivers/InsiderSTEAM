using UnityEngine;

public class ProblemDisplayerMovement : MonoBehaviour
{
    // Public self reference
    public static ProblemDisplayerMovement instance;
    // Private attributes
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Get components
        animator = GetComponent<Animator>();
    }

    // Move down function
    public void GoDown()
    {
        animator.SetBool("canAnswer", true);
    }

    // Move up function
    public void GoUp()
    {
        animator.SetBool("canAnswer", false);
    }
}
