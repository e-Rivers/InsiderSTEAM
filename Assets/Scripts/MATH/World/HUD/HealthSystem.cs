using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    // Public attributes
    [SerializeField] GameObject fullHeartPrefab;
    [SerializeField] GameObject emptyHeartPrefab;

    // Draw a new heart
    public void DrawHearts(int currHearts, int maxHearts)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        for (int i = 0; i < maxHearts; i++)
        {
            if (i + 1 <= currHearts)
            {
                GameObject heart = Instantiate(fullHeartPrefab, transform.position, Quaternion.identity);
                heart.transform.SetParent(transform);
            }
            else
            {
                GameObject heart = Instantiate(emptyHeartPrefab, transform.position, Quaternion.identity);
                heart.transform.SetParent(transform);
            }
        }
    }
}
