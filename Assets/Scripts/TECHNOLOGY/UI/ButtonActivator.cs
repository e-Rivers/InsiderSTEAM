using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    // Private attributes
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        btn = GetComponent<Button>();
        btn.onClick.AddListener(CheckWin);
    }

    public void CheckWin()
    {
        Debug.Log(TileManager.instance.CheckWin());
    }
}
