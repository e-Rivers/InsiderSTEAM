using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    // Public attributes
    public static EnemyControl instance;
    public int smallEnemies = 0;
    public int mediumEnemies = 0;
    public int bigEnemies = 0;
    public bool canTriggerSounds = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
