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
        // Set components
        btn = GetComponent<Button>();
        scn = SceneManager.GetActiveScene();
        btn.onClick.AddListener(ReloadScene);
        // Set values
        canReload = false;
    }

    // Reloads scene
    void ReloadScene()
    {
        if (canReload)
        {
            Debug.Log("Decided to reload from ");
            SceneManager.LoadScene(scn.name);
            canReload = false;
        }
    }
    
}
