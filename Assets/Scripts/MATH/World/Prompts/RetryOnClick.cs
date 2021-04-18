using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryOnClick : MonoBehaviour
{
    // Public self reference
    public static RetryOnClick instance;
    // Public attributes
    public bool canReload;

    // Start is called before the first frame update
    void Start()
    {
        // Set public reference
        instance = this;
        // Set values
        canReload = false;
    }

    // Reloads scene
    public void ReloadScene()
    {
        if (canReload)
        {
            canReload = false;
            MenuManager.instance.GotoMath();
        }
    }
    // Goes to main menu
    public void LoadMainMenu()
    {
        MenuManager.nextScene = "MainMenu";
        MenuManager.instance.EnterScene();
    }
}
