using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public static MenuManager instance;
    public GameObject menu,profile,credits,playgame;

    // Start is called before the first frame update
    void Start() {
        instance = this;
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Open Credits
    public void displayCredits() {
	menu.SetActive(false);
	credits.SetActive(true);
    }
    
    // Open Menu
    public void displayMenu() {
	playgame.SetActive(false);
	credits.SetActive(false);
	profile.SetActive(false);
	menu.SetActive(true);
    }

    // Open Profile
    public void displayProfile() {
	menu.SetActive(false);
	profile.SetActive(true);
    }

    // Open Play
    public void displayPlayGame() {
	menu.SetActive(false);
	playgame.SetActive(true);
    }


    // Methods to change to the correspoding level (World)
    public void GotoScience() { SceneManager.LoadScene("ScienceLevel"); }
    public void GotoTechnology() { SceneManager.LoadScene("TechRealm"); }
    public void GotoEngineering() { SceneManager.LoadScene("TechRealm"); }
    public void GotoArts() { SceneManager.LoadScene("ArtRealm"); }
    public void GoToLoadScreen(string realm) {
        switch (realm) {
            case "math":
                SceneManager.LoadScene("MathLoadScreen");
                break;
        }
    }
    public void GotoMathematics() { SceneManager.LoadScene("MathRealm"); }

}



















