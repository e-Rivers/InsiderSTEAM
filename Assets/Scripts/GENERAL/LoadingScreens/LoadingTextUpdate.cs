using UnityEngine;
using UnityEngine.UI;

public class LoadingTextUpdate : MonoBehaviour
{
    // Public attributes
    public static LoadingTextUpdate instance;
    public bool stop;
    // Private attributes
    private Text text;
    private string[] letters;
    private float changeTime;
    private float timer;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        text = GetComponent<Text>();
        changeTime = 0.2f;
        timer = 0.0f;
        letters = new string[] { "C", "A", "R", "G", "A", "N", "D", "O", ".", ".", ".", "."};
        counter = 0;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop) 
        {
            if (timer >= changeTime)
            {
                timer = 0.0f;
                text.text += letters[counter];
                if (counter < letters.Length - 1)
                {
                    counter++;
                }
                else
                {
                    text.text = "";
                    counter = 0;
                }
            } else
            {
                timer += Time.deltaTime;
            }
        } else {
            text.text = "";
        }
    }
}
