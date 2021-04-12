using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameObject menu,profile,credits;

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
	credits.SetActive(false);
	profile.SetActive(false);
	menu.SetActive(true);
    }

    // Open Profile
    public void displayProfile() {
	menu.SetActive(false);
	profile.SetActive(true);
    }

}



















