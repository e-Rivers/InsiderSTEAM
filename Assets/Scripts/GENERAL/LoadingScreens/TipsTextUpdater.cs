using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsTextUpdater : MonoBehaviour
{
    // Public attributes
    public float tipSwitchTime = 7.0f;                 // Time at which tips should be switched
    // Private attributes
    private Text text;                                  // Reference to the tips' Text object
    private Color color;                                // Reference to the Text object's color
    private Dictionary<string, string[]> tips;          // Declaration of a Dictionary containing tips according to the current level
    private List<int> usedTips = new List<int>();       // List containing previously used tips

    // Start is called before the first frame update
    void Start()
    {
        // Get tips text's components
        text = GetComponent<Text>();
        color = text.color;
        // Initialize dictionary
        tips = new Dictionary<string, string[]>()
        {
            {"MathLevel", new string[] { "¡Los colores de cada plataforma indican propiedades diferentes! Por ejemplo: Las plataformas naranjas sólo te permitirán saltar sobre ellas una vez.",
                                         "Cada vez que te cuelgues de 3 plataformas verdes, tu personaje obtendrá 2 vidas más.",
                                         "¡Ten cuidado con disparar demasiado! Si estás cerca de derrotar a 10 enemigos, correrás el riesgo de disparar a una respuesta equivocada.",
                                         "¡Las plataformas azul-obscuro te protegen! Si te agarras de una, esta lanzará un gran proyectil que destruye a todo enemigo a su paso.",
                                         "Agarrarte de plataformas superiores puede darte diferentes ventajas según su color.",
                                         "Aunque saltar de una plataforma roja te da una gran altura, no podrás hacer un doble salto hasta saltar sobre otra plataforma."
                                  }
            },
            {"TechLevel", new string[] {

                                       }
            }
        };
        // Check if key exists within the dictionary
        if (tips.ContainsKey(MenuManager.nextScene))
        {
            // Display the first tip and start the tip-switching coroutine
            StartCoroutine("SwitchTip");
        }
    }

    // Change a tip
    void SetNewTip()
    {
        // Register current index for string arrays inside the tips dictionary
        int index = Random.Range(0, tips[MenuManager.nextScene].Length);
        // Check if usedTips List still doesn't have the same number of elements as the string arrays from the tips dictionary
        if (usedTips.Count != tips[MenuManager.nextScene].Length)
        {
            // Repeat if index current index value is already in the usedTips List
            while (usedTips.Contains(index))
            {
                // Change the current index
                index = Random.Range(0, tips[MenuManager.nextScene].Length);
            }
        }
        else
        {
            // Empty usedTips List if it has the same number of elements as the string arrays from the tips dictionary
            usedTips.Clear();
        }
        // Once a valid index is found, add it to usedTips
        usedTips.Add(index);
        // Update text
        text.text = tips[MenuManager.nextScene][index];
    }

    // Coroutine to switch between the available tips
    IEnumerator SwitchTip()
    {
        // Repeat coroutine indefinitely
        while (true)
        {
            SetNewTip();
            yield return new WaitForSeconds(tipSwitchTime);
        }
    }
}
