using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCounter : MonoBehaviour
{
    // Public self reference 
    public static AnswerCounter instance;
    // Public attributes
    public int correctAnswers;
    public int correctThreshold = 3;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set initial values
        correctAnswers = 0;
    }
}
