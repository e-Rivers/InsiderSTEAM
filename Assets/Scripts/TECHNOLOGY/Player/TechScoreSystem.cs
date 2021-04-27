using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TechScoreSystem : MonoBehaviour
{
    // Public attributes
    public static TechScoreSystem instance;
    public static int score = 0;
    public static int mistakes = 0;

    // Private attributes
    [SerializeField] Text timeDisplay;
    private float timer;
    private float seconds;
    private int minutes;
    private int hours;
    private int multiplier;
    private int bonus;
    private string strSeconds;
    private string strMinutes;
    private string strHours;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        timer = 600.0f;
        seconds = 0f;
        minutes = 0;
        hours = 0;
        multiplier = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        // Add seconds
        seconds += Time.deltaTime;
        // Run multiplier timer
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        // Run time counter
        if (seconds >= 60)
        {
            seconds = 0f;
            minutes += 1;
            if (minutes >= 60)
            {
                minutes = 0;
                hours += 1;
            }
        }
        // Update time text
        if (hours < 10)
        {
            strHours = "0" + hours.ToString();
        }
        else
        {
            strHours = hours.ToString();
        }
        if (minutes < 10)
        {
            strMinutes = "0" + minutes.ToString();
        }
        else
        {
            strMinutes = minutes.ToString();
        }
        if (seconds < 10)
        {
            strSeconds = "0" + (int)(seconds);
        }
        else
        {
            strSeconds = "" + (int)(seconds);
        }
        timeDisplay.text = strHours + ":" + strMinutes + ":" + strSeconds;
    }

    // Get score
    public int GetLevelScore()
    {
        bonus = 500 * (LevelManager.instance.maxLevels - mistakes);
        return 350 + (int)Mathf.Floor(multiplier * timer / 600.0f) + bonus;
    }

    // Reset if player exits
    public void OnPlayerExit()
    {
        score = 0;
        mistakes = 0;
    }
}
