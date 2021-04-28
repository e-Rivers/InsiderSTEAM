using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject DestroyedC;
    private Animator anim;
    private bool crash = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnGUI()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level 1" && crash)
        {
            DestroyedC.GetComponent<DestroyedCoins>().DestroyedC = 0;
            SceneManager.LoadScene("Level 1");
        }
        else if (scene.name == "Level 2" && crash)
        {
            DestroyedC.GetComponent<DestroyedCoins>().DestroyedC = 0;
            SceneManager.LoadScene("Level 2");
        }
        else if (scene.name == "Level 3" && crash)
        {
            DestroyedC.GetComponent<DestroyedCoins>().DestroyedC = 0;
            SceneManager.LoadScene("Level 3");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KillerPlatform"))
        {
            anim.SetBool("crash", true);
            crash = true;
        }
    }
}
