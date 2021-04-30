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
    private bool begin;
    public Sprite[] Sprite_Pic;
    private int[] randomNProblems;
    private int j = 0;
    private int x;
    private bool nextLevel = false;
    private Scene scene;
    [SerializeField] Canvas canvas;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victorySound;
    [SerializeField] Button backToMenuButton;
    public GameObject a;
    void Start()
    {
        System.Random rnd = new System.Random();
        randomNProblems = System.Linq.Enumerable.Range(0, 13).OrderBy(r => rnd.Next()).ToArray();
        a.GetComponent<EnterAnswer>().ReceiveRandomNProblems(randomNProblems);
        canvas.enabled = false;
        begin = false;
        audioSource = GameObject.Find("SoundSource").GetComponent<AudioSource>();
        scene = SceneManager.GetActiveScene();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!begin)
            {
                EngAnswerTimer.instance.ResetAnswerTimer();
                begin = true;
            }
            if (scene.name == "Level 1" && i == 1 && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 7)
            {
                begin = true;
            }
            else if (scene.name == "Level 2" && i == 1 && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 9)
            {
                begin = true;
            }
            else if (scene.name == "Level 3" && i == 1 && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 9)
            {
                begin = true;
            }
        }
    }

    private void OnGUI()
    {
        if (scene.name == "Level 1" && i == 1 && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 7)
        {
            Change();
            i++;
        }
        else if (scene.name == "Level 2" && i == 1 && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 9)
        {
            Change();
            i++;
        }
        else if (scene.name == "Level 3" && i == 1 && begin && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 9)
        {
            Change();
            i++;
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
            MoveCharacter.instance.disableInput = true;
            EngPauseMenu.instance.canPause = false;
            canvas.enabled = true;
            nextLevel = true;
            audioSource.PlayOneShot(victorySound);
            if (SceneManager.GetActiveScene().name.Equals("Level 3"))
            {
                backToMenuButton.gameObject.SetActive(false);
            }
        }
    }

    public void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level 1" && nextLevel)
        {
            MenuManager.nextScene = "Level 2";
            MenuManager.instance.EnterScene(false);
        }
        else if (scene.name == "Level 2" && nextLevel)
        {
            MenuManager.nextScene = "Level 3";
            MenuManager.instance.EnterScene(false);
        }
        else if (scene.name == "Level 3" && nextLevel || Input.GetKeyDown(KeyCode.L))
        {
            EngPauseMenu.instance.GoToMenu();
            GeneralScore.totalScore = 0;
        }
    }
}