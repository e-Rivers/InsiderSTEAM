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
    public int level = 0;
    public bool win = false;
    private bool isFirst;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set isFirst variable
        isFirst = true;
        win = false;
    }

    void Update()
    {
        if (isFirst)
        {
            // Set level
            int level = LevelManager.level;
            Debug.Log("InstructionManager level: " + level);
            // Get current painting
            currPainting = paintings[level];
            // Set children as active
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            // Get current instructions
            switch (level)
            {
                case 0:
                    instructions = new GameObject[] { ColorSystem.instance.colorsDict["yb"], ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["yrb"] };
                    break;
                case 1:
                    instructions = new GameObject[] { ColorSystem.instance.colorsDict["yb"], ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["w"] };
                    break;
                case 2:
                    instructions = new GameObject[] { ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["nw"], ColorSystem.instance.colorsDict["bbr"] };
                    break;
                case 3:
                    instructions = new GameObject[] { ColorSystem.instance.colorsDict["yrb"], ColorSystem.instance.colorsDict["y"], ColorSystem.instance.colorsDict["nw"] };
                    break;
                case 4:
                    instructions = new GameObject[] { ColorSystem.instance.colorsDict["r"], ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["n"] };
                    break;
                case 5:
                    instructions = new GameObject[] { ColorSystem.instance.colorsDict["by"], ColorSystem.instance.colorsDict["nw"], ColorSystem.instance.colorsDict["yr"] };
                    break;
                case 6:
                    instructions = new GameObject[] { ColorSystem.instance.colorsDict["yr"], ColorSystem.instance.colorsDict["by"], ColorSystem.instance.colorsDict["yrb"] };
                    break;
            }
            // Set required colors
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Image>().sprite = instructions[i].GetComponent<SpriteRenderer>().sprite;
                transform.GetChild(i).GetComponent<Image>().color = instructions[i].GetComponent<SpriteRenderer>().color;
            }
            isFirst = false;
        }
    }
}
