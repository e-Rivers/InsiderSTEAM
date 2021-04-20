using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueConfirm : MonoBehaviour
{
    // Public attributes
    public string realm = "Tech";
    // Private attributes
    [SerializeField] Text dialogue;
    [SerializeField] Button button;
    private int maxClicks = 6;
    private int clicks;
    private Dictionary<string, string[]> dialogues;
    // Start is called before the first frame update
    void Start()
    {
        clicks = 0;
        dialogues = new Dictionary<string, string[]>() {
            {"Tech", new string[] { "En este momento estamos viajando al pasado, puesto que La Ignorancia intentó alterar la historia...",
                                   "...porque teme que La Tecnología se convierta en un peligro para la humanidad y termine por dominarnos.",
                                   "¡No lo podemos permitir! ¡La Tecnología es un aliado sumamente importante para conocer más sobre el universo!",
                                   "Para ayudarnos a combatir este mal, deberás desarrollar tu lógica resolviendo los acertijos que nos dejó nuestro enemigo.",
                                   "Deberás encontrar las figuras ocultas, siguiendo el número de celdas activas por filas y columnas.",
                                   "Si logramos encontrarlas, ¡nuestras habilidades serán mucho mayores para derrotar a La Ignorancia!"}
            }
        };
        maxClicks = dialogues[realm].Length;
        button.enabled = false;
        StartCoroutine("DisplayDialogue");
    }

    public void ConfirmDialogue()
    {
        button.enabled = false;
        clicks++;
        if (clicks < maxClicks)
        {
            StartCoroutine("DisplayDialogue");
        }
        else
        {
            MenuManager.nextScene = "TechLevel";
            MenuManager.instance.EnterScene(false);
        }
    }

    IEnumerator DisplayDialogue()
    {
        dialogue.text = "";
        for (int i = 0; i < dialogues[realm][clicks].Length; i++)
        {
            dialogue.text += dialogues[realm][clicks][i];
            yield return new WaitForSeconds(0.01f);
        }
        button.enabled = true;
    }

}
