using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLever : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {    
        
        if (Input.GetKeyDown(KeyCode.X) && GameObject.Find("DestroyedCoins").GetComponent<DestroyedCoins>().DestroyedC == 9)
        {
            GetComponent<Animator>().Play("Lever");
        }
    }
}
