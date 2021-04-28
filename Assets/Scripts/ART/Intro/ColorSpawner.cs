using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSpawner : MonoBehaviour
{
    // Private attributes
    [SerializeField] GameObject colorDrop;
    private Color[] colors = new Color[] { new Color(1f, 0.9575586f, 1f), new Color(0.3425901f, 0.07784498f, 0.6037736f), new Color(1f, 1f, 1f), new Color(1f, 0f, 0f),
                                           new Color(0f, 0.9802451f, 1f), new Color(1f, 0.5795525f, 0f), new Color(0.2595613f, 1f, 0f), new Color(0f, 0f, 0f)};

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnColor");
    }

    // Spawn colours at random
    IEnumerator SpawnColor()
    {
        while (true)
        {
            float randomZ = Random.Range(0, 359);
            GameObject drop = Instantiate(colorDrop, transform.position, Quaternion.Euler(0, 0, randomZ));
            drop.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
            drop.GetComponent<Rigidbody2D>().velocity = -drop.transform.up;
            Destroy(drop, 15.0f);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
