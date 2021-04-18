using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    public void CheckWin()
    {
        if (TileManager.instance.CheckWin())
        {
            TechEndingScreen.instance.SetScreen();
        }
    }
}
