using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSystem : MonoBehaviour
{
        //Public attributes
        public static ColorSystem instance;  
        public GameObject[] colors;                                                                                 // List of all possible colors
        public string currentSearch;
        public Dictionary<string, GameObject> colorsDict;
        public GameObject currentColor;

        // Start is called before the first frame update
        void Start()
        {
            // Initial variables assignment
            instance = this;
            // Initialize color dictionary
            colorsDict = new Dictionary<string, GameObject>() {
                {"", colors[0]},            //None
                {"n", colors[1]},           //Black
                {"b", colors[2]},           //Blue  
                {"y", colors[3]},           //Yellow
                {"r", colors[4]},           //Red
                {"by", colors[5]},          //Green
                {"yb", colors[5]},          //Green
                {"yr", colors[6]},          //Orange
                {"ry", colors[6]},          //Orange
                {"br", colors[7]},          //Violet  
                {"rb", colors[7]},          //Violet
                {"bbr", colors[8]},         //Blue-Violet
                {"brb", colors[8]},         //Blue-Violet
                {"rbb", colors[8]},         //Blue-Violet
                {"yrbbr", colors[9]},       //Brown
                {"yrbrb", colors[9]},       //Brown
                {"yrrbb", colors[9]},       //Brown
                {"rybbr", colors[9]},       //Brown
                {"rybrb", colors[9]},       //Brown
                {"ryrbb", colors[9]},       //Brown
                {"byr", colors[10]},        //White
                {"bry", colors[10]},        //White
                {"ybr", colors[10]},        //White
                {"rby", colors[10]},        //White
                {"ryb", colors[10]},         //White           
                {"nbyr", colors[11]},
                {"nbry", colors[11]},
                {"nybr", colors[11]},
                {"nrby", colors[11]},
                {"nryb", colors[11]},
                {"byrn", colors[11]},
                {"bryn", colors[11]},
                {"ybrn", colors[11]},
                {"rbyn", colors[11]},
                {"rybn", colors[11]}
            };
            // Set black as default color
            currentSearch = "";
        }

        // Update is called on every frame update
        private void Update()
        {
            if (colorsDict.ContainsKey(currentSearch)) {
                currentColor = colorsDict[currentSearch];
                Debug.Log(colorsDict[currentSearch].gameObject.name);
            } else {
                currentSearch = "";
            }
        }

        // Function to change current color
        public void AddColor(string identifier) {
            if (identifier != currentSearch) {
                currentSearch = currentSearch + identifier;
            }
        }
    }