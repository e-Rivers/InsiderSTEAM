using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsTextUpdater : MonoBehaviour
{

    // Private attributes
    private Text text;
    private Color color;
    private Dictionary<string, string[]> tips;
    private List<int> usedTips = new List<int>();
    private float tipTimer;
    private float tipSwitchTime = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        color = text.color;
        tips = new Dictionary<string, string[]>()
        {
            {"MathLevel", new string[] { "�Los colores de cada plataforma indican propiedades diferentes! Por ejemplo: Las plataformas naranjas s�lo te permitir�n saltar sobre ellas una vez.",
                                    "�Sab�as que cada vez que te cuelgues de 3 plataformas verdes, tu personaje obtendr� 2 vidas m�s?",
                                    "�Ten cuidado con disparar demasiado! Si est�s cerca de derrotar a 10 enemigos, correr�s el riesgo de disparar a una respuesta equivocada cuando aparezca un problema matem�tico.",
                                    "�Las plataformas azul-obscuro te protegen! Si te agarras de una, �sta lanzar� un gran proyectil que destruye a todo enemigo a su paso.",
                                    "Agarrarte de plataformas superiores puede traerte diferentes ventajas seg�n su color.",
                                    "Aunque saltar de una plataforma roja te da una gran altura, no podr�s hacer un doble salto hasta saltar sobre otra plataforma."
                                  }
            }
        };
        if (tips.ContainsKey(MenuManager.nextScene))
        {
            SetNewTip(MenuManager.nextScene);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tips.ContainsKey(MenuManager.nextScene))
        {
            if (tipTimer >= tipSwitchTime)
            {
                SetNewTip(MenuManager.nextScene);
                tipTimer = 0.0f;
            }
            else
            {
                tipTimer += Time.deltaTime;
            }
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
        }
        else
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
