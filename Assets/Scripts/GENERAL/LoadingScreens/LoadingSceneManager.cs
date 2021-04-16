using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    // Public attributes
    public float loadTime = 5.0f;
    public Text continueText;
    public Image scienceBack, techBack, engineBack, artsBack, mathsBack, menuBack;

    // Private attributes
    private float timer;
    private float textTimer;
    private int textCounter;
    private bool canContinue;

    // Start is called before the first frame update
    void Start()
    {
	// Selects the background
	switch(MenuManager.sceneToLoad) {
	    case "ScienceLevel":
		scienceBack.gameObject.SetActive(true); break;
	    case "TechRealm":
		techBack.gameObject.SetActive(true); break;
	    case "EngineRealm":
		engineBack.gameObject.SetActive(true); break;
	    case "ArtRealm":
		artsBack.gameObject.SetActive(true); break;
	    case "MathRealm":
		mathsBack.gameObject.SetActive(true); break;
	    case "MainMenu":
		menuBack.gameObject.SetActive(true); break;
	}

        // Set components
        continueText.text = "";
        // Set values
        timer = 0.0f;
        textTimer = 0.0f;
        textCounter = 0;
        canContinue = false;
    }

    // Update is called once per frame
    void Update()
    {
        // See if charge time is completed
        if (timer < loadTime)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0.0f;
            canContinue = true;
        }
        // If charge time is completed
        if (canContinue) {
            LoadingTextUpdate.instance.stop = true;
            if (textTimer < 1.0f) {
                textTimer += Time.deltaTime;
            } else {
                if (textCounter % 2 == 0) {
                    continueText.text = "PRESIONA 'ESPACIO' PARA CONTINUAR";
                } else {
                    continueText.text = "";
                }
                textCounter++;
                textTimer = 0.0f;
            }
        }
        // Check user input
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canContinue) {
                SceneManager.LoadScene(MenuManager.sceneToLoad);
            }
        }
    }
}
