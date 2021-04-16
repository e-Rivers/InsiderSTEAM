using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArtCanvasCollector : MonoBehaviour
{
    // Public attributes
    public static ArtCanvasCollector instance;
    public GameObject splash;
    // Private attributes
    private List<string> colors = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Try to add color
    public void TryAddColor(string color) {
        if (!colors.Contains(color)) {
            for (int i = 0; i < InstructionManager.instance.instructions.Length; i++) {
                if (color == InstructionManager.instance.instructions[i].GetComponent<ColorBehaviour>().identifier) {
                    Debug.Log("Dropped color ID: " + color + ". Instruction color ID: " + InstructionManager.instance.instructions[i].GetComponent<ColorBehaviour>().identifier);
                    // Add color to list
                    colors.Add(color);
                    // Create random position
                    float randomX = Random.Range(6.15f, 8.5f);
                    float randomY = Random.Range(-1.13f, -2.23f);
                    Vector3 randomPos = new Vector3(randomX, randomY, 0);
                    // Create splash gameObject
                    GameObject splashInstance = Instantiate(splash, randomPos, Quaternion.identity);
                    splashInstance.GetComponent<SpriteRenderer>().color = ColorSystem.instance.colorsDict[color].GetComponent<SpriteRenderer>().color;
                    splashInstance.transform.parent = transform;
                    // Reset player's color
                    ColorSystem.instance.currentSearch = "";
                    // Check if player wins
                    if (colors.Count == InstructionManager.instance.instructions.Length) {
                        Debug.Log("Win!");
                        InstructionManager.instance.win = true;
                    }
                }
            } 
        }
    }
}
