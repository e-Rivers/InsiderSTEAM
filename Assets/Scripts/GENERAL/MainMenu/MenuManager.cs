using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class MenuManager : MonoBehaviour
{
    // Public attributes
    public static string nextScene;
    public static MenuManager instance;
    public GameObject menu, story, playgame;

    // Private attributes
    private int currentChar = 0;
    private bool transition = true;
    private bool isOnSubmenu;
    private Coroutine changeMenuChar;
    [SerializeField] Image title;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        // Set self reference
        instance = this;
        // Set private attributes
        isOnSubmenu = false;
        // If current scene is Main Menu
        if (title != null)
        {
            // Enables title animation
            anim = title.GetComponent<Animator>();
        }
        // If current scene is Login Screen
        if (SceneManager.GetActiveScene().name.Equals("LoginScreen"))
        {
            changeMenuChar = StartCoroutine(changeCharacter());
        }
    }
    
    // Open Menu
    public void displayMenu()
    {
        // Change title position
        isOnSubmenu = false;
        anim.SetBool("isOnSubmenu", isOnSubmenu);
        // Enable visual elements
        playgame.SetActive(false);
        story.SetActive(false);
        menu.SetActive(true);
    }

    // Open Story
    public void displayStory()
    {
        // Change title position
        isOnSubmenu = true;
        anim.SetBool("isOnSubmenu", isOnSubmenu);
        // Enable visual elements
        menu.SetActive(false);
        story.SetActive(true);
    }

    // Open Play
    public void displayPlayGame()
    {
        // Change title position
        isOnSubmenu = true;
        anim.SetBool("isOnSubmenu", isOnSubmenu);
        // Enable visual elements
        menu.SetActive(false);
        playgame.SetActive(true);
    }

    // Method to go to the loading screen
    public void EnterScene(bool load = true)
    {
        if (SceneManager.GetActiveScene().name.Equals("LoginScreen"))
        {
            StopCoroutine(changeMenuChar);
        }
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
    public void GotoScience() { nextScene = "ScienceLevelIntro"; EnterScene(); }
    public void GotoMath() { nextScene = "MathLevelIntro"; EnterScene(); }
    public void GotoTech() { nextScene = "TechLevelIntro"; EnterScene(); }
    public void GotoArt() { nextScene = "ArtLevelIntro"; EnterScene(); }
    public void GotoEngineering() { nextScene = "EngineeringLevelIntro"; EnterScene(); }

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

    // Method to exit application
    public void exitGame()
    {
        Application.Quit();
    }

    // Method to logout
    public void logOut()
    {
        PlayerPrefs.SetString("nickname", "");
        PlayerPrefs.Save();
        SceneManager.LoadScene("LoginScreen");
    }
}















