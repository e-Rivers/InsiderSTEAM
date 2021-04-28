
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnterAnswer : MonoBehaviour
{
    public string Answer;
    public GameObject inputField;
    public GameObject textDisplay;
    private int[] answersLevel1 = { 1, 2, 3, 4, 5 };

    public void StoreAnswer()
    {
        Answer = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Tu respuesta fue " + Answer;
    }
}
