using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsTextUpdater : MonoBehaviour
{
    // Public attributes
    public string realm;

    // Private attributes
    private Text text;
    private Color color;
    private Dictionary<string, string[]> tips;
    private List<int> usedTips = new List<int>();
    private float tipTimer;
    private float opacityTimer;
    private float tipSwitchTime = 5.0f;
    private float opacitySwitchTime = 0.5f;
    private float rate;
    private bool canSwitch;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        color = text.color;
        canSwitch = true;
        tips = new Dictionary<string, string[]>()
        {
            {"math", new string[] { "¡Los colores de cada plataforma indican propiedades diferentes! Por ejemplo: Las plataformas naranjas sólo te permitirán saltar sobre ellas una vez.",
                                    "¿Sabías que cada vez que te cuelgues de 3 plataformas verdes, tu personaje obtendrá 2 vidas más?",
                                    "¡Ten cuidado con disparar demasiado! Si estás cerca de derrotar a 10 enemigos, correrás el riesgo de disparar a una respuesta equivocada cuando aparezca un problema matemático.",
                                    "¡Las plataformas azul-obscuro te protegen! Si te agarras de una, ésta lanzará un gran proyectil que destruye a todo enemigo a su paso.",
                                    "Agarrarte de plataformas superior puede traerte diferentes ventajas según su color.",
                                    "Aunque saltar de una plataforma roja te da una gran altura, no podrás hacer un doble salto hasta saltar sobre otra plataforma."
                                  } 
            }
        };
        SetNewTip(realm);
    }

    // Update is called once per frame
    void Update()
    {
        if (tipTimer >= tipSwitchTime)
        {
            if (color.a > 0)
            {
                color.a -= Time.deltaTime * rate;
                text.color = color;
                Debug.Log("Text color transparency: " + text.color.a);
            } else
            {
                if (canSwitch)
                {
                    Debug.Log("Switched tip text.");
                    SetNewTip(realm);
                    canSwitch = false;
                }
                if (color.a < 1)
                {
                    Debug.Log("Text color transparency: " + text.color.a);
                    color.a += Time.deltaTime * 0.5f;
                    text.color = color;
                } else
                {
                    tipTimer = 0.0f;
                    canSwitch = true;
                }
            }
        } else
        {
            tipTimer += Time.deltaTime;
            Debug.Log("Time elapsed: " + tipTimer);
        }
    }

    // Change a tip
    void SetNewTip(string currRealm)
    {
        // Register current index for string arrays inside the tips dictionary
        int index = Random.Range(0, tips[currRealm].Length);
        // Check if usedTips List still doesn't have the same number of elements as the string arrays from the tips dictionary
        if (usedTips.Count != tips[currRealm].Length)
        {
            // Repeat if index current index value is already in the usedTips List
            while (usedTips.Contains(index))
            {
                // Change the current index
                index = Random.Range(0, tips[currRealm].Length);
            }
        } else
        {
            // Empty usedTips List if it has the same number of elements as the string arrays from the tips dictionary
            usedTips.Clear();
        }
        // Once a valid index is found, add it to usedTips
        usedTips.Add(index);
        // Update text
        text.text = tips[currRealm][index];
    }
}
