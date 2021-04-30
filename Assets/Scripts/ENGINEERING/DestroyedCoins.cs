using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedCoins : MonoBehaviour
{
    public static DestroyedCoins instance;
    public int DestroyedC = 0;

    void Start()
    {
        instance = this;
    }

}
