using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetryOnClick : MonoBehaviour
{
    // Public self reference
    public static RetryOnClick instance;
    // Public attributes
    public bool canReload;
    // Private attributes
    private Scene scn;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        // Set public reference
        instance = this;
        scn = SceneManager.GetSceneByBuildIndex(1);
        // Set components
        btn = GetComponent<Button>();
        btn.onClick.AddListener(ReloadScene);
        // Set values
        canReload = false;
    }

    // Reloads scene
    void ReloadScene()
    {
        if (canReload)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Debug.Log("Escena " + i + ": " + SceneManager.GetSceneAt(i).name);
            }
            canReload = false;
        }
    }
    
}
