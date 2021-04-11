using UnityEngine;
using UnityEngine.UI;

public class ReloadText : MonoBehaviour
{
    // Private attributes
    private static Text text;
    private static bool canPlaySound = true;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.text = "";
    }
    
    // Display reload text
    public static void DisplayReload()
    {
        text.text = "PULSA \'R\' PARA RECARGAR";
        if (canPlaySound)
        {
            PlayerSounds.instance.PlayReloadPrompt();
            canPlaySound = false;
        }

    }

    // Empty textbox
    public static void EmptyText()
    {
        if (text.isActiveAndEnabled)
        {
            text.text = "";
            canPlaySound = true;
        }
    }
}
