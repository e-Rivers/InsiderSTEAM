using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static string nextScene;
    public static MenuManager instance;
    public GameObject menu, profile, credits, playgame;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        nextScene = "MathRealm";
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
    public void EnterScene()
    {
        SceneManager.LoadScene("LoadingScene");
    }

    // Methods to change to the correspoding level (World)
    public void GotoScience() { nextScene = "ScienceLevel"; EnterScene(); }
    public void GotoMath() { nextScene = "MathLevel"; EnterScene(); }
    public void GotoTech() { nextScene = "TechLevel"; EnterScene(); }
    public void GotoArt() { nextScene = "ArtLevel"; EnterScene(); }
    public void GotoEngineering() { nextScene = "ArtLevel"; EnterScene(); }

}















