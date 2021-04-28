using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsTextUpdater : MonoBehaviour
{
    // Public attributes
    public float tipSwitchTime = 7.0f;                 // Time at which tips should be switched
    // Private attributes
    [SerializeField] Text title;
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
            {"MathLevelIntro", new string[] { "¡Los colores de cada plataforma indican propiedades diferentes! Por ejemplo: Las plataformas naranjas sólo te permitirán saltar sobre ellas una vez.",
                                         "Cada vez que te cuelgues de 3 plataformas verdes, tu personaje obtendrá 2 vidas más.",
                                         "¡Ten cuidado con disparar demasiado! Si estás cerca de derrotar a 10 enemigos, correrás el riesgo de disparar a una respuesta equivocada.",
                                         "¡Las plataformas azul-obscuro te protegen! Si te agarras de una, esta lanzará un gran proyectil que destruye a todo enemigo a su paso.",
                                         "Agarrarte de plataformas superiores puede darte diferentes ventajas según su color.",
                                         "Aunque saltar de una plataforma roja te da una gran altura, no podrás hacer un doble salto hasta saltar sobre otra plataforma."
                                       }
            },
            {"MainMenu", new string[] { "...las multiplicaciones dan el mismo el resultado sin importar el orden en el que las hagas?",
                                        "...el arte llegó a ser un evento Olímpico entre 1912 y 1948?",
                                        "...no podrías saborear tu comida si no fuera por la saliva?",
                                        "...Motorola realizó la primer llamada desde un teléfono móvil en 1973?",
                                        "...los teclados tienen las letras alfabéticamente separadas para evitar que se escriba demasiado rápido?",
                                        "...los colores son producto un fenómeno de la luz conocido como \"refracción\"? ¡La luz puede dividirse en colores! Este descubrimiento dio origen a la rueda de colores conocida universalmente.",
                                        "...la mayor parte de los símbolos matemáticos no se definieron hasta el siglo XVI? ¡Antes de eso, la gente utilizaba palabras para definir operaciones!",
                                        "...el símbolo de división (÷) se llama \'óbelo\'?",
                                        "...la palabra SPAM del correo está basada en \"El Circo Volador\" de Monty Python?",
                                        "...los números 2 y 5 son los únicos números primos que terminan en 2 y 5?",
                                        "...no existe una representación del cero en los numerales romanos?",
                                        "...existen esculturas del tamaño del orificio de una aguja? Willard Wigan es uno de los principales artistas que trabajan en este tipo de obras.",
                                        "...la Mona Lisa tiene su propio buzón de correo debido a todas las cartas de amor que recibe?",
                                        "...si lograras doblar el mismo papel por la mitad 103 veces, tendría el mismo grosor que el universo observable?",
                                        "...practicar alguna de las distintas artes puede ayudarte a mejorar tu lectura y tu capacidad matemática?",
                                        "...Picasso aprendió a dibujar antes de aprender a caminar?",
                                        "...la imaginación y el pensamiento crítico pueden desarrollarse a través del arte?",
                                        "...las mujeres representan el 60% de las graduaciones universitarias?",
                                        "...existen tornados más veloces que un carro Fórmula 1?",
                                        "...las nubes son blancas porque reflejan la luz solar sobre ellas?",
                                        "...el viento no produce ruido alguno a menos que golpee algo?",
                                        "...Nokia comenzó vendiendo papel de baño?",
                                        "...tu nariz y tus orejas nunca dejan de crecer?",
                                        "...además de las huellas digitales, nuestras lenguas también tienen patrones irrepetibles?",
                                        "...las espirales de los girasoles siguen una secuencia numérica conocida como Secuencia Fibonacci?",
                                        "...sumar los números desde el 1 hasta el 9 da como resultado 100?",
                                        "...un círculo siempre tendrá un área mayor que cualquier otra figura geométrica con el mismo perímetro?",
                                        "...Venus es el único planeta que gira en el sentido de las manecillas del reloj?",
                                        "...Leonardo da Vinci fue una activista en favor de los derechos animales?",
                                        "...las estatuas romanas generalmente tenían cabezas removibles para poderlas reemplazar fácilmente?",
                                        "...el logotipo de Firefox no es un zorro, sino un panda rojo?",
                                        "...la palabra \"robot\" proviene de la palabra checa \"robota\", que significa \"trabajo forzado\"?",
                                        "...la primer vídeo-cámara era del tamaño de un piano clásico?",
                                        "...el primer mouse de computadora era rectangular y estaba hecho de madera?",
                                        "...Amazon solía llamarse \'Cadabra\'?",
                                        "...por cada 23 personas, dos de ellas probablemente comparten el mismo día de cumpleaños?",
                                        "...PI representado como fracción es 22 sobre 7?"
                                      }
            },
            {"TechLevelIntro", new string[] { "Las figuras normalmente son simétricas, por lo que si quieres comenzar una figura, deberías intentarlo desde el centro de las filas o las columnas.",
                                         "¡No olvides revisar los números de las filas o las columnas! Si son amarillos, puede que hayas completado un patrón correctamente.",
                                         "Si consigues dar clic sobre el cursor que se encuentra en el juego, este te dirá un recuadro que debe estar activado.",
                                         "¿Sientes que es demasiado complicado modificar los recuadros? ¡Prueba reiniciando el nivel!",
                                         "Aunque puede ser de gran ayuda recibir pistas del cursor, tu puntuación se verá afectada negativamente por cada pista que este proporcione."
                                       }
            },
            {"ArtLevelIntro", new string[] { "Si consigues un color que no es el que querías, trata de hacer una combinación de colores que no exista para deshacerte de él.",
                                        "Aunque los colores blanco y negro no forman parte de los primarios, estos caerán del cielo en caso de requerir formar colores como el gris.",
                                        "¡Entre más pronto completes la combinación de colores requerida, más puntos recibirás!",
                                        "No es necesario seguir un orden específico para combinar los colores o completar las instrucciones. ¡Puedes hacerlo a tu manera!",
                                        "Si recoges dos colores idénticos, el color actual se preservará, por lo que no debes esquivarlos."
                                      }
            },
            {"ScienceLevelIntro", new string[] { "Procura identificar primero la salida del laberinto para que encuentres el camino correcto más fácilmente.",
                                                 "¡Muchos de los acertijos te serán más fáciles de resolver si piensas fuera de la caja!",
                                                 "Ejercitar tu memoria es muy importante para encontrar tu camino hacia la salida. ¡Eventualmente lo conseguirás!",
                                                 "¡No te preocupes si no logras completar el laberinto a tiempo! Aún tendrás la oportunidad de resolver un acertijo."
                                               }
            }
        };
        // Check if key exists within the dictionary
        if (tips.ContainsKey(MenuManager.nextScene))
        {
            // Check if player is going to a level, an intro screen or the main menu
            if (MenuManager.nextScene.EndsWith("Intro"))
            {
                title.text = "TIP:";
            }
            else
            {
                title.text = "SABÍAS QUE...";
            }
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
