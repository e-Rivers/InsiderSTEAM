using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLever : MonoBehaviour
{

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip leverClip;
    private bool move = false;
    private bool playedOnce = false;

    // 
    void Start()
    {
        audioSource = GameObject.Find("SoundSource").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            switch (SceneManager.GetActiveScene().name)
            {
                case "Level 1":
                    if (GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 7)
                    {
                        Debug.Log("Can move");
                        move = true;
                    }
                    break;
                case "Level 2":
                    if (GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 9)
                    {
                        Debug.Log("Can move");
                        move = true;
                    }
                    break;
                case "Level 3":
                    if (GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 9)
                    {
                        Debug.Log("Can move");
                        move = true;
                    }
                    break;

            }
        }
    }

    private void OnGUI()
    {
        // Get active scene
        Scene scene = SceneManager.GetActiveScene();
        if (!playedOnce)
        {
            if (scene.name == "Level 1" && move && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 7)
            {
                GetComponent<Animator>().Play("Lever");
                audioSource.PlayOneShot(leverClip);
            }
            else if (scene.name == "Level 2" && move && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 9)
            {
                GetComponent<Animator>().Play("Lever");
                audioSource.PlayOneShot(leverClip);
            }
            else if (scene.name == "Level 3" && move && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC >= 9)
            {
                GetComponent<Animator>().Play("Lever");
                audioSource.PlayOneShot(leverClip);
            }
            playedOnce = true;
        }
    }
}
