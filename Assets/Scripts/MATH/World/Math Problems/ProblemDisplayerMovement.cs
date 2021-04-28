using System.Collections;
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

    // Enable displayer movement
    public void Move(bool appear)
    {
        if (appear)
        {
            animator.SetBool("canAnswer", true);
        }
        else
        {
            animator.SetBool("canAnswer", false);
        }
    }
}
