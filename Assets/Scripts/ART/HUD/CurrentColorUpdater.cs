using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentColorUpdater: MonoBehaviour
{
    // Public attributes
    public GameObject currentColor;

    // Private attributes
    private RectTransform rect;
    private Image img;
    private Text colorText;

    // Start is called before the first frame update
    void Start()
    {
        // Get components
        rect = transform.GetChild(0).GetComponent<RectTransform>();
        img = transform.GetChild(0).GetComponent<Image>();
        colorText = transform.GetChild(1).GetComponent<Text>();
        // Set values
        img.sprite = currentColor.GetComponent<SpriteRenderer>().sprite;
        colorText.text = "SIN COLOR";
    }

    // Update is called once per frame
    void Update()
    {
        currentColor = ColorSystem.instance.currentColor;
        img.sprite = currentColor.GetComponent<SpriteRenderer>().sprite;
        img.color = currentColor.GetComponent<SpriteRenderer>().color;
        colorText.text = currentColor.name.ToUpper();
        if (colorText.text.Equals("SIN COLOR") || colorText.text.Equals("BLANCO")) {
            colorText.color = new Color(0, 0, 0);
        } else if (colorText.text.Equals("AZUL") || colorText.text.Equals("AMARILLO")) {
            colorText.color = MakeDarker(currentColor.GetComponent<SpriteRenderer>().color);
        } else {
            colorText.color = currentColor.GetComponent<SpriteRenderer>().color;
        }
        if (colorText.text.Equals("SIN COLOR")) {
            rect.localScale = new Vector3 (0.8f, 1, 1);        
        } else {
            rect.localScale = new Vector3 (1f, 1, 1);
        }
    }

    private Color MakeDarker(Color color) {
        // Returns darker color
        return new Color(color.r - 0.3f, color.g - 0.3f, color.b - 0.3f);
    }
}
