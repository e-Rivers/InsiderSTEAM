using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueConfirm : MonoBehaviour
{
    // Private attributes
    [SerializeField] Text dialogue;
    private int clicks;
    private string[] dialogues;
    // Start is called before the first frame update
    void Start()
    {
        clicks = 0;
        dialogues = new string[] { "En este momento estás viajando por el tiempo, puesto que alguien intentó alterar la historia...",
                                   "...puesto que teme que la tecnología se convierta en un peligro para la humanidad y termine por dominarnos.",
                                   "¡No lo podemos permitir! ¡La tecnología es un aliado sumamente importante para conocer más sobre el universo!",
                                   "Para ayudarnos a combatir este mal, debemos resolver los acertijos que La Ignorancia nos dejó...",
                                   "¡Para ello deberás encontrar las figuras ocultas, siguiendo el número de celdas activas por filas y columnas!",
                                   "Si logramos encontrarlas, nuestra destreza será mucho mejor para derrotar a La Ignorancia."};
    }

    public void ConfirmDialogue()
    {
        if (clicks < 6)
        {
            dialogue.text = dialogues[clicks];
            clicks++;
        }
        else
        {
            MenuManager.nextScene = "TechRealm";
            MenuManager.instance.EnterScene();
        }
    }
}
