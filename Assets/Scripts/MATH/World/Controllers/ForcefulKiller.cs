using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForcefulKiller : MonoBehaviour
{
    // Public self reference
    public static ForcefulKiller instance;
    // Private attributes
    private BoxCollider2D boxColl;
    // Start is called before the first frame update
    void Start()
    {
        // Get self reference
        instance = this;
        // Get components
        boxColl = GetComponent<BoxCollider2D>();
        // Assign component values
        boxColl.enabled = false;
    }

    // Enable box collider
    public void Enable()
    {
        boxColl.enabled = true;
    }

    // Disble box collider
    public void Disable()
    {
        boxColl.enabled = false;
    }
}
