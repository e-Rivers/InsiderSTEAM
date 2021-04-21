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

    public Image science, tech, engine, arts, maths;
    private int currentChar = 0;
    private bool transition = true;
    private Coroutine changeMenuChar;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        changeMenuChar = StartCoroutine(changeCharacter());
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
    public void GotoMath() { nextScene = "MathLevel"; EnterScene(); }
    public void GotoTech() { nextScene = "TechLevelIntro"; EnterScene(); }
    public void GotoArt() { nextScene = "ArtLevel"; EnterScene(); }
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
}















