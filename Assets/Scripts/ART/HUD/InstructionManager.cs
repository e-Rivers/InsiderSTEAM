using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    // Public attributes
    public static InstructionManager instance;
    public Sprite[] paintings;
    public Sprite currPainting;
    public GameObject[] instructions;
    public static int level = 0;
    public bool win = false;

    // Private attributes
    private static List<int> levels = new List<int>();
    private bool isFirst;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set isFirst variable
        isFirst = true;
        win = false;
        // Get a random new level number
        int rndLevel = Random.Range(0, 7);
        // If list of levels has less than 5 elements
        if (levels.Count < 7) {
            // Repeat
            while (true) {
                // If picked level number has already been picked before
                if (levels.Contains(rndLevel)) {
                    // Set a new level number
                    rndLevel = Random.Range(0, 7);
                // Otherwise, add to level numbers List and set level
                } else {
                    level = rndLevel;
                    levels.Add(rndLevel);
                    break;
                }
            }
        // Otherwise, clear list and set new random level
        } else {
            levels.Clear();
            level = rndLevel;
            levels.Add(rndLevel);
        }
        // Get current painting
        currPainting = paintings[level];
    }

    void Update() {
        if (isFirst) {
            // Get current instructions
            switch (level) {
                case 0:
                    instructions = new GameObject[] {ColorSystem.instance.colorsDict["yb"], ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["yrb"]};
                    break;
                case 1: 
                    instructions = new GameObject[] {ColorSystem.instance.colorsDict["yb"], ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["w"]};
                    break;
                case 2:
                    instructions = new GameObject[] {ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["nw"], ColorSystem.instance.colorsDict["bbr"]};
                    break;
                case 3:
                    instructions = new GameObject[] {ColorSystem.instance.colorsDict["yrb"], ColorSystem.instance.colorsDict["y"], ColorSystem.instance.colorsDict["nw"]};
                    break;
                case 4:
                    instructions = new GameObject[] {ColorSystem.instance.colorsDict["r"], ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["b"]};
                    break;
                case 5:
                    instructions = new GameObject[] {ColorSystem.instance.colorsDict["by"], ColorSystem.instance.colorsDict["nw"], ColorSystem.instance.colorsDict["yr"]};
                    break;
                case 6:
                    instructions = new GameObject[] {ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["by"], ColorSystem.instance.colorsDict["yrb"]};
                    break;
            }
            // Set required colors
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).GetComponent<Image>().sprite = instructions[i].GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).GetComponent<Image>().color = instructions[i].GetComponent<SpriteRenderer>().color;
            }
            isFirst = false;
        }
    }
}
