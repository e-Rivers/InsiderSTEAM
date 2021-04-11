using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlatformDestroyer : MonoBehaviour
{
    // Public attributes
    public GameObject toBeDestroyed;

    // Destroy referenced gameObject
    public void DestroyPlatform()
    {
        if (toBeDestroyed != null)
        {
            Destroy(toBeDestroyed);
        }
    }
}
