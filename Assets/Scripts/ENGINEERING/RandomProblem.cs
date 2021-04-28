using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class RandomProblem : MonoBehaviour
{
    private int i = 1;
    private bool begin = false;
    public Sprite[] Sprite_Pic;
    private int[] randomNProblems;
    private int j = 0;
    private int x;
    private bool nextLevel = false;
    void Start()
    {
        System.Random rnd = new System.Random();
        randomNProblems = System.Linq.Enumerable.Range(0, 13).OrderBy(r => rnd.Next()).ToArray();
        Array.ForEach(randomNProblems, Console.WriteLine);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            begin = true;
        }
    }

    private void OnGUI()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level 1" && i == 1 && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 7)
        {
            Change();
            i++;
        }
        else if (scene.name == "Level 2" && i == 1 && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 9)
        {
            Change();
            i++;
        }
        else if (scene.name == "Level 3" && i == 1  && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 9)
        {
            Change();
            i++;
        }

        if (scene.name == "Level 1" && nextLevel)
        {
            SceneManager.LoadScene("Level 2");
        }
        else if (scene.name == "Level 2" && nextLevel)
        {
            SceneManager.LoadScene("Level 3");
        }
    }

    public void Change()
    {
        if (j <= 4)
        {
            x = randomNProblems[j];
            GetComponent<SpriteRenderer>().sprite = Sprite_Pic[x];
            j++;
        }
        else
        {
            nextLevel = true;
        }
    }
}