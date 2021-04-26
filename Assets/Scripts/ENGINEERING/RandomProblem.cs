using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomProblem : MonoBehaviour
{
    private int rand;
    private int i = 1;
    public Sprite[] Sprite_Pic;
    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && i==1)
        {
            Change();
            i = i + 1;
        }
    }

    void Change()
    {
        rand = Random.Range(0, Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
    }

}