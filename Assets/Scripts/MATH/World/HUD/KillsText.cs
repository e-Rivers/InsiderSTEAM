using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillsText : MonoBehaviour
{
    // Public attributes
    public static int kills = 0;
    public static Text killsText;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        killsText = GetComponent<Text>();
        // Set kill values
        kills = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (kills != 1)
        {
            killsText.text = kills + " enemigos derrotados";
        } else
        {
            killsText.text = kills + " enemigo derrotado";
        }
    }
}
