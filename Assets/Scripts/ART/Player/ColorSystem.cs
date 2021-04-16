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
                {"yrb", colors[9]},       //Brown
                {"ybr", colors[9]},       //Brown
                {"bry", colors[9]},       //Brown
                {"byr", colors[9]},       //Brown
                {"rby", colors[9]},       //Brown
                {"ryb", colors[9]},       //Brown
                {"w", colors[10]},        //White
                {"nw", colors[11]},       
                {"wn", colors[11]}
            };
            // Set black as default color
            currentSearch = "";
            currentColor = colorsDict[currentSearch];
        }

        // Update is called on every frame update
        private void Update()
        {
            if (colorsDict.ContainsKey(currentSearch)) {
                currentColor = colorsDict[currentSearch];
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