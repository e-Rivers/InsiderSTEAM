using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class MenuManager : MonoBehaviour
{
    public static string nextScene;
    public static MenuManager instance;
    public GameObject menu, profile, credits, playgame;

    public Image science, tech, engine, arts, maths;
    private int currentChar = 0;
    private bool transition = true;
    private Coroutine changeMenuChar, loadUserData;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        changeMenuChar = StartCoroutine(changeCharacter());
        // Loads user data and stats
        loadUserData = StartCoroutine(downloadData());
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentChar)
        {
            case 0:
                makeTransition(maths, science);
                break;
            case 1:
                makeTransition(science, tech);
                break;
            case 2:
                makeTransition(tech, engine);
                break;
            case 3:
                makeTransition(engine, arts);
                break;
            case 4:
                makeTransition(arts, maths);
                break;
        }
    }

    // Method to make the transition of the characters
    private void makeTransition(Image toQuit, Image toShow)
    {
        if (SceneManager.GetActiveScene().name.Equals("MainMenu"))
        {
            toQuit.gameObject.SetActive(false);
            toShow.gameObject.SetActive(true);
            if (transition)
            {
                toShow.canvasRenderer.SetAlpha(0);
                toShow.CrossFadeAlpha(1, 1, false);
                transition = false;
            }
        }
    }

    // Open Credits
    public void displayCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }

    // Open Menu
    public void displayMenu()
    {
        playgame.SetActive(false);
        credits.SetActive(false);
        profile.SetActive(false);
        menu.SetActive(true);
    }

    // Open Profile
    public void displayProfile()
    {
        menu.SetActive(false);
        profile.SetActive(true);
    }

    // Open Play
    public void displayPlayGame()
    {
        menu.SetActive(false);
        playgame.SetActive(true);
    }

    // Method to go to the loading screen
    public void EnterScene(bool load = true)
    {
        StopCoroutine(changeMenuChar);
        if (load)
        {
            SceneManager.LoadScene("LoadingScene");
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
        Debug.Log("Going to " + MenuManager.nextScene);
    }

    // Methods to change to the correspoding level (World)
    public void GotoScience() { nextScene = "ScienceLevel"; EnterScene(); }
    public void GotoMath() { nextScene = "MathLevelIntro"; EnterScene(); }
    public void GotoTech() { nextScene = "TechLevelIntro"; EnterScene(); }
    public void GotoArt() { nextScene = "ArtLevelIntro"; EnterScene(); }
    public void GotoEngineering() { nextScene = "Level 3"; EnterScene(); }

    // Coroutine to change the current displayed character
    private IEnumerator changeCharacter()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            if (currentChar == 4) { currentChar = 0; }
            else { currentChar++; }
            transition = true;
        }
    }
    
    // Coroutine to download user data and stats
    private IEnumerator downloadData() {
    	string URIresource = "http://18.116.123.111:8080/insider/datosJugadorUnity/" + PlayerPrefs.GetString("nickname");
		UnityWebRequest request = UnityWebRequest.Get(URIresource);
		// Executes the request
		yield return request.SendWebRequest(); 
		// After the request has completed, checks if it was successful
		if(request.result == UnityWebRequest.Result.Success) {
			string returnMsg = request.downloadHandler.text;
			// 
			Debug.Log(returnMsg);
		} else {
			//errorMessages.text = "ERROR DE CONEXIÓN: " + request.responseCode.ToString();
		}
    }
    
    // Method to exit application
    public void exitGame() {
    	Application.Quit();
    }
    
    // Method to logout
    public void logOut() {
    	PlayerPrefs.SetString("nickname", "");
    	PlayerPrefs.Save();
    	SceneManager.LoadScene("LoginScreen");
    }
}















