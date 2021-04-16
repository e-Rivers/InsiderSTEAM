using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public static string sceneToLoad;
    public GameObject menu,profile,credits,playgame;

    // Start is called before the first frame update
    void Start() {
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

    // Method to go to the loading screen
    public void GoToLoadScreen() { SceneManager.LoadScene("LoadingScene"); }

    // Methods to change to the correspoding level (World)
    public void GotoScience() { sceneToLoad = "ScienceLevel";  GoToLoadScreen(); }
    public void GotoTechnology() { sceneToLoad = "TechRealm";  GoToLoadScreen(); }
    public void GotoEngineering() { sceneToLoad = "EngineRealm";  GoToLoadScreen(); }
    public void GotoArts() { sceneToLoad = "ArtRealm";  GoToLoadScreen(); }
    public void GotoMathematics() { sceneToLoad = "MathRealm"; GoToLoadScreen(); }

}



















