using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtCanvasCollector : MonoBehaviour
{
    // Public attributes
    public static ArtCanvasCollector instance;
    public GameObject splash;
    public bool correct;
    // Private attributes
    private List<string> colors = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        correct = false;
    }

    // Try to add color
    public void TryAddColor(string color)
    {
        // Set flag
        correct = false;
        // If attempted color hasn't been already added
        if (!colors.Contains(color))
        {
            // Iterate through every current needed color
            for (int i = 0; i < InstructionManager.instance.instructions.Length; i++)
            {
                // If the attempted color's identifier is equal to one of the needed color's identifier
                if (color == InstructionManager.instance.instructions[i].GetComponent<ColorBehaviour>().identifier)
                {
                    // Add color to list
                    colors.Add(color);
                    // Set current color as correct
                    correct = true;
                    // Create random position
                    float randomX = Random.Range(6.15f, 8.5f);
                    float randomY = Random.Range(-1.13f, -2.23f);
                    Vector3 randomPos = new Vector3(randomX, randomY, 0);
                    // Create splash gameObject
                    GameObject splashInstance = Instantiate(splash, randomPos, Quaternion.identity);
                    splashInstance.GetComponent<SpriteRenderer>().color = ColorSystem.instance.colorsDict[color].GetComponent<SpriteRenderer>().color;
                    splashInstance.transform.parent = transform;
                    // Remove needed color from needed colors list
                    InstructionManager.instance.transform.GetChild(i).gameObject.SetActive(false);
                    // Reset player's color
                    ColorSystem.instance.currentSearch = "";
                    // Check if player wins
                    if (colors.Count == InstructionManager.instance.instructions.Length)
                    {
                        InstructionManager.instance.win = true;
                        PaintingDisplayer.instance.EnableCanvas();
                    }
                }
            }
        }
    }
}
