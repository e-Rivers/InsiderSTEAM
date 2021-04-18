using UnityEngine;
using UnityEngine.UI;

public class ColumnChecker : MonoBehaviour
{
    // Public attributes
    public static ColumnChecker instance;
    public Transform child;
    public Text[] texts;

    // Private attributes
    private bool isFirstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        instance = this;
        texts = new Text[15];
        child = transform.GetChild(0);
        for (int i = 0; i < 15; i++)
        {
            texts[i] = child.GetChild(i).GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstTime)
        {
            int[][] matrix = TileManager.instance.winnerMatrix;
            int counter = 0;
            string result = "";

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    // If there are ones inside the array
                    if (matrix[j][i] == 1)
                    {
                        // Add to counter
                        counter++;
                        // If there's a next element
                        if (j + 1 < 15)
                        {
                            // If next element is 0
                            if (matrix[j + 1][i] == 0)
                            {
                                result += counter + "\n";
                                counter = 0;
                            }
                        }
                        else
                        {
                            result += counter + "\n";
                        }
                    }
                }
                texts[i].text = result;
                result = "";
                counter = 0;
            }
            isFirstTime = false;
        }
    }
}
