using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScienceCanvasOperations : MonoBehaviour {

    public GameObject initialBanner;
    public static string sidebarAns = "", endingAns = "";
    public Button regButton, endButton;
    public InputField regInput, endInput;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    // This method will remove the initial banner
    public void removeBanner() {
        initialBanner.SetActive(false);
    }

    // Method to capture user input in every round
    public void captureRegInput() {
        sidebarAns = regInput.text;
    }

    // Method to capture user input at the end of the game
    public void captureEndInput() {
        endingAns = endInput.text;
    }

}

















