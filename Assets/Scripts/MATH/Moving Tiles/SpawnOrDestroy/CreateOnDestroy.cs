using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOnDestroy : MonoBehaviour
{
    // Public attributes
    public GameObject nextExplosion;

    // Update is called once per frame
    private void OnDestroy()
    {
        if (nextExplosion != null)
        {
            nextExplosion.SetActive(true);
        }
    }
}
