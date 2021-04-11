using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSystem : MonoBehaviour
{
    // Ammo shells images
    // Public attributes
    [SerializeField] GameObject fullAmmoPrefab;
    [SerializeField] GameObject emptyAmmoPrefab;

    // Draw ammo shells
    public void DrawShells(int currShells, int maxShells)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < maxShells; i++)
        {
            if (i + 1 <= currShells)
            {
                GameObject heart = Instantiate(fullAmmoPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }
            else
            {
                GameObject heart = Instantiate(emptyAmmoPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }
        }
    }
}
