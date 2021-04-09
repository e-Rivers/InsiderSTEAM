using UnityEngine;
using UnityEngine.UI;

public class ResumeOnClick : MonoBehaviour
{
    // Public attributes

    // Private attributes
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        // Get button component and add listener to it
        btn = GetComponent<Button>();
        btn.onClick.AddListener(UnpauseGame);
    }

    // Call unpause function from PauseMenu script
    void UnpauseGame()
    {
        PauseMenu.instance.UnpauseGame();
    }
}
