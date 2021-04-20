using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectColors : MonoBehaviour
{
    //Public attributes
    public int black;
    public int red;
    public int blue;
    public int yellow;


    // Start is called before the first frame update
    void Start()
    {
        //Counter for each color
        red = 0;
        blue = 0;
        yellow = 0;
        black = 0;
    }

    //Checking how many drops the player collect, by its color
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Color")
        {
            if (other.gameObject.GetComponent<ColorBehaviour>().identifier.Equals(0))
            {
                black++;
            }
            if (other.gameObject.GetComponent<ColorBehaviour>().identifier.Equals(1))
            {
                blue++;
            }
            if (other.gameObject.GetComponent<ColorBehaviour>().identifier.Equals(2))
            {
                yellow++;
            }
            if (other.gameObject.GetComponent<ColorBehaviour>().identifier.Equals(3))
            {
                red++;
            }
            ColorSystem.instance.AddColor(other.gameObject.GetComponent<ColorBehaviour>().identifier);
        }
    }

}

