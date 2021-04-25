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
        canReload = true;
    }

    // Reloads scene
    public void ReloadScene()
    {
        if (canReload)
        {
            canReload = false;
            Time.timeScale = 1.0f;
            MenuManager.nextScene = "MathLevel";
            MenuManager.instance.EnterScene(false);
        }
    }
    // Goes to main menu
    public void LoadMainMenu()
    {
        Time.timeScale = 1.0f;
        MenuManager.nextScene = "MainMenu";
        MenuManager.instance.EnterScene();
    }
}
