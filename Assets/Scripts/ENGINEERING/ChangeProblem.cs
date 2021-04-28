using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeProblem : MonoBehaviour
{
    public string Answer;
    public GameObject inputField;
    public GameObject textDisplay;
    private int[] nproblem = { 1, 2, 3, 4, 5 };
    private int[] answers = { 1, 2, 3, 4, 5 };

    public void StoreAnswer()
    {
        Answer = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Your answer was " + Answer;
    }
}
