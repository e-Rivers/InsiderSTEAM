using UnityEngine;
using UnityEngine.UI;

public class ProblemText : MonoBehaviour
{
    // Public self reference
    public static ProblemText instance;
    // Public attributes
    public Text problemText;    // Displays the current math problem

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Sets the UI to display the math problem
    public void SetProblemText(Problem problem)
    {
        // set the problem text to display the problem
        problemText.text = problem.firstNumber + setOperator(problem.firstOperation) + problem.secondNumber + setOperator(problem.secondOperation) + problem.thirdNumber;
    }

    // Empty the UI display
    public void EmptyProblemText(bool correct)
    {
        if (correct)
        {
            problemText.text = "CORRECT! :)";
        } else
        {
            problemText.text = "INCORRECT :(";
        }
    }

    // Set string according to operator
    string setOperator(MathOperation operation)
    {
        string operatorText = "";
        // Convert the problem's operator from an enum to an actual text symbol
        switch (operation)
        {
            case MathOperation.Addition: operatorText = " + "; break;
            case MathOperation.Substraction: operatorText = " - "; break;
            case MathOperation.Multiplication: operatorText = " x "; break;
            case MathOperation.Division: operatorText = " ÷ "; break;
        }
        return operatorText;
    }
}
