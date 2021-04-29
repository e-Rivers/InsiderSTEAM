using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingInfo : MonoBehaviour
{
    // Public attributes
    public static PaintingInfo instance;
    public Text titleText;
    public Text descText;
    public Dictionary<int, string> paintingsTitles = new Dictionary<int, string>()
    {
        {0, "La Creación de las Aves"},
        {1, "Mujer Saliendo del Psicoanalista"},
        {2, "Caravana"},
        {3, "Papilla Estelar"},
        {4, "Nacer de Nuevo"},
        {5, "El Gato Helecho"},
        {6, "Mimetismo"}
    };
    public Dictionary<int, string> paintingsInfo = new Dictionary<int, string>()
    {
        {0, "La lechuza desempeña el oficio de pintor, pero es a la vez un científico, alquimista, astrónomo y músico: la creación, la vida, nace a partir del centro del cuerpo de esta lechuza."},
        {1, " “Soltar es lo que se debe hacer al salir del psicoanálisis”, es lo que nos dice Remedios en referencia a lo que la mujer de cabello blanco y manta verde sostiene con su mano izquierda, un rostro que está por soltar a un pozo"},
        {2, "El interior de la caravana está pintada en tonos dorados, que irradian del centro del lienzo. Remedios interpreta con presición el interior desde diversas perspectivas de manera que los salones y escaleras crean un laberinto de espacios de dirección que cambian a medida que se van alejando"},
        {3, "Remedios representó en varias obras la posibilidad de que la mujer llegue a quedar atrapada en el ambito doméstico; Papilla estelar es un ejemplo de ellas, en la que una mujer sentada en una solitaria torre, que flota entre las nubes, tritura sustancia estelar para hacer una papilla con la que alimenta a una luna creciente cautuva en una jaula."},
        {4, "El escenario es un recinto sagrado en el fondo de un bosque. Hay también una mujer que traspasa una pared y llega a su revelación con una total inocencia, como si acabara de nace. Al ver un cáliz lleno de líquido, ve el reflejo de una luna creciente, por lo que queda estupefacta, pues se le ha permitido entrar en un secreto."},
        {5, "El Gato Helecho de 1957 fue inspirado en el sueño de su amiga Eva Sulzer: “Un día tuve un sueño y se lo narré a Remedios, soñé que paseaban por el jardín unos gatos que se habían convertido en helechos, pero los helechos no estaban pegados al gato con su misma forma sino que era como si salieran de ellos. Remedios pintó ese cuadro El gato helecho y me lo regaló...”"},
        {6, "Esta señora se ha quedado tanto rato pensativa e inmovil que se ha transformado en el sillón, su piel ahora tiene su forma, color y textura, mientras ella permanece aún inmovil y pensativa."}
    };

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Get Text components for title and description
        titleText = transform.GetChild(0).GetComponent<Text>();
        descText = transform.GetChild(1).GetComponent<Text>();
        // Disable Texts temporarily 
        titleText.enabled = false;
        descText.enabled = false;
    }

    // Update is called on every frame update
    void Update()
    {

    }

    // Set title and description text
    public void SetInfo(int currLevel)
    {
        // Enable Texts and update information
        titleText.enabled = true;
        descText.enabled = true;
        titleText.text = paintingsTitles[currLevel].ToUpper();
        descText.text = paintingsInfo[currLevel];
    }
}
