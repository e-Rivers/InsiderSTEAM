using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveLever : MonoBehaviour
{
    // Update is called once per frame

    private bool move = false;
    void Update()
    {    
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            move = true;
        }
    }

    private void OnGUI()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level 1" && move && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 7)
        {
            GetComponent<Animator>().Play("Lever");
        }
        else if (scene.name == "Level 2" && move && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 9)
        {
            GetComponent<Animator>().Play("Lever");
        }
        else if (scene.name == "Level 3" && move && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 9)
        {
            GetComponent<Animator>().Play("Lever");
        }
    }
}
