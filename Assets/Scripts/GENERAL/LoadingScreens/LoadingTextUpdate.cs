using UnityEngine;
using UnityEngine.UI;

public class LoadingTextUpdate : MonoBehaviour
{
    // Private atributes
    private Text text;
    private string[] letters;
    private float changeTime;
    private float timer;
    private int counter;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        changeTime = 0.2f;
        timer = 0.0f;
        letters = new string[] { "C", "A", "R", "G", "A", "N", "D", "O", ".", ".", ".", "."};
        Debug.Log(letters);
        counter = 0;
    }

    // Update is called once per frame
    void Update()
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
    }
}
