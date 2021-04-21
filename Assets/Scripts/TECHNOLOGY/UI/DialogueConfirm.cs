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
    [SerializeField] Image bg;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip beep;
    private int maxClicks = 6;
    private int clicks;
    private Dictionary<string, string[]> dialogues;

    // Start is called before the first frame update
    void Start()
    {
        // Reset variables
        clicks = 0;
        // Dialogues according to realm
        dialogues = new Dictionary<string, string[]>() {
            {"Tech", new string[] { "En este momento estamos viajando al pasado, puesto que La Ignorancia intentó alterar la historia...",
                                   "...porque teme que La Tecnología se convierta en un peligro para la humanidad y termine por dominarnos.",
                                   "¡No lo podemos permitir! ¡La Tecnología es un aliado sumamente importante para conocer más sobre el universo!",
                                   "Para ayudarnos a combatir este mal, deberás desarrollar tu lógica resolviendo los acertijos que nos dejó nuestro enemigo.",
                                   "Deberás encontrar las figuras ocultas, siguiendo el número de celdas activas por filas y columnas.",
                                   "Si logramos encontrarlas, ¡nuestras habilidades serán mucho mayores para derrotar a La Ignorancia!"}
            }
        };
        // Set number of maximum clicks according to the current realm
        maxClicks = dialogues[realm].Length;
        // Reset button and background visibility
        button.enabled = false;
        bg.enabled = true;
        // Display first dialogue
        StartCoroutine("DisplayDialogue");
    }

    // Skip to next dialogue
    public void ConfirmDialogue()
    {
        // Deactivate button once it's clicked
        button.enabled = false;
        // Add number of clicks
        clicks++;
        // If max number of clicks hasn't been reached
        if (clicks < maxClicks)
        {
            // Display next dialogue
            StartCoroutine("DisplayDialogue");
        }
        else
        {
            // Do transition
            bg.enabled = true;
            StartCoroutine("EnableTransition");
        }
    }

    // Dialogue animation
    IEnumerator DisplayDialogue()
    {
        // Empty dialogue box
        dialogue.text = "";
        // Add character to dialogue box
        for (int i = 0; i < dialogues[realm][clicks].Length; i++)
        {
            dialogue.text += dialogues[realm][clicks][i];
            audioSource.PlayOneShot(beep);
            yield return new WaitForSeconds(0.02f);
        }
        // Disable background
        if (bg.enabled)
        {
            bg.enabled = false;
        }
        // Once the dialogue is complete, enable button to skip to next dialogue
        button.enabled = true;
    }

    // Transition animation
    IEnumerator EnableTransition()
    {
        // Add transparency to image
        while (bg.color.a < 1)
        {
            Debug.Log(bg.color.a);
            bg.color += new Color(0f, 0f, 0f, 0.05f);
            yield return null;
        }
        // After transition animated is complete, load next scene
        MenuManager.nextScene = "TechLevel";
        MenuManager.instance.EnterScene(false);
    }

}
