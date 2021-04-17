using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingInfo : MonoBehaviour
{
    // Public attributes
    public static PaintingInfo instance;
    // Private attributes
    private Text titleText;
    private Text descText;
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
        {0, ""},
        {1, ""},
        {2, ""},
        {3, ""},
        {4, ""},
        {5, "El Gato Helecho de 1957 fue inspirado en el sueño de su amiga Eva Sulzer: “Un día tuve un sueño y se lo narré a Remedios, soñé que paseaban por el jardín unos gatos que se habían convertido en helechos, pero los helechos no estaban pegados al gato con su misma forma sino que era como si salieran de ellos. Remedios pintó ese cuadro El gato helecho y me lo regaló...”"},
        {6, ""}
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
        if (InstructionManager.instance.win)
        {
            // Enable Texts and update information
            titleText.enabled = true;
            descText.enabled = true;
        }
        else
        {
            // Disable Texts temporarily 
            titleText.enabled = false;
            descText.enabled = false;
        }
    }

    // Set title and description text
    public void SetInfo(int currLevel)
    {
        titleText.text = paintingsTitles[currLevel].ToUpper();
        descText.text = paintingsInfo[currLevel];
    }
}
