using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterAnswer : MonoBehaviour
{
    public string Answer;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StoreAnswer()
    {
        Answer = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Your answer was " + Answer;
    }
}
