using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDDisplayManager : MonoBehaviour
{
    // Public self reference
    public static HUDDisplayManager instance;

    // Private attributes
    private Canvas canvas;

    // Start is called before first frame update
    private void Start()
    {
        // Set self reference
        instance = this;
        // Set private components
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    public void EnableHUD()
    {
        canvas.enabled = true;
    }

    public void DisableHUD()
    {
        if (canvas != null)
        {
            canvas.enabled = false;
        }
    }
}
