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
    private int maxClicks;
    private int clicks;
    private Dictionary<string, string[]> dialogues;

    // Start is called before the first frame update
    void Start()
    {
        // Reset variables
        clicks = 0;
        // Dialogues according to realm
        dialogues = new Dictionary<string, string[]>() {
            {"Tech", new string[] {"En este momento estamos viajando al pasado, puesto que La Ignorancia intentó alterar la historia...",
                                   "...porque teme que La Tecnología se convierta en un peligro para la humanidad y termine por dominarnos.",
                                   "¡No lo podemos permitir! ¡La Tecnología es un aliado sumamente importante para conocer más sobre el universo!",
                                   "Para ayudarnos a combatir este mal, deberás desarrollar tu lógica resolviendo los acertijos que nos dejó nuestro enemigo.",
                                   "¡Encuentra tres figuras ocultas! Para entonces tendrás una habilidad lógica mucho mayor...",
                                   "¡Si logramos esta misión, estaremos aún más cerca de debilitar a La Ignorancia!"}
            },
            {"Math", new string[] {"Así que has encontrado tu camino al Futuro, al Reino Olvidado de las Matemáticas...",
                                   "¡Ja! Todos creían que sin Matemáticas el mundo sería más sencillo, así que decidieron simplemente olvidarlas...",
                                   "Lo creerás imposible, pero así es como resultó para tu especie... Creen que viven bien, cuando en realidad no viven así.",
                                   "Creen que lo tienen todo resuelto, pero sólo permitieron que el dominio de La Ignorancia se expandiera a través del mundo.",
                                   "Por eso me ves aquí, porque junto a mis compañeros, es mi deber que La Ingorancia continúe reinando sobre tu planeta...",
                                   "Pero aún quedan rastros de las Matemáticas, pequeños problemas sin resolver que planeamos destruir pronto... ",
                                   "Si alguien encontrara las respuestas, tu mundo tendría una chispa de esperanza, pero dudo que alguien lo haga.",
                                   "¡Adelante, intenta! Nuestro ejército te espera..."}
            },
            {"Art", new string[] { "¡Necesito tu ayuda! ¡La Ignorancia planea erradicar las pinturas de todos los museos en el universo!",
                                   "Por favor, entra y ayúdanos a que los colores vuelvan a sus pinturas originales, pues Remedios Varo está sufriendo los...",
                                   "...primeros pasos de este malvado plan, pues están robando los colores de cada una de sus pinturas.",
                                   "Sé que es mucho pedir, pero así como ahora tengo vida, pronto podré extinguirme junto con otras galerías del mundo...",
                                   "...y eso sólo hará el trabajo de La Ignorancia más fácil."
                                 }
            }
        };
        // Set number of maximum clicks according to the current realm
        maxClicks = dialogues[realm].Length;
        // Reset button and background visibility
        button.enabled = true;
        bg.enabled = true;
        // Display first dialogue
        StartCoroutine("DisplayDialogue");
    }

    // Skip to next dialogue
    public void ConfirmDialogue()
    {
        // Add number of clicks
        clicks++;
        // If max number of clicks hasn't been reached
        if (clicks < maxClicks)
        {
            // Display next dialogue
            StopCoroutine("DisplayDialogue");
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
        if (bg.enabled)
        {
            bg.enabled = false;
        }
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
        switch (realm)
        {
            case "Tech":
                MenuManager.nextScene = "TechLevel";
                break;
            case "Math":
                MenuManager.nextScene = "MathLevel";
                Time.timeScale = 0f;
                break;
            case "Art":
                MenuManager.nextScene = "ArtLevel";
                break;
        }
        MenuManager.instance.EnterScene(false);
    }

}
