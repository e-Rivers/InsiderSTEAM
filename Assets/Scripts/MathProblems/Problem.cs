[System.Serializable]
public class Problem
{
    // Public attributes
    public float firstNumber;               // First number to operate with
    public float secondNumber;              // Second number to operate with
    public float thirdNumber;
    public MathOperation firstOperation;    // First operation to be performed
    public MathOperation secondOperation;   // Second operation to be performed
    public float[] answers;                 // All possible answers
    public int correctTile;                 // Index of correct tile to be shot

}

// Enumerator to define every possible operator
public enum MathOperation
{
    Addition,
    Substraction,
    Multiplication,
    Division
}

