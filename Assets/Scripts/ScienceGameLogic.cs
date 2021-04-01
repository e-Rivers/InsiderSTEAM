using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScienceGameLogic : MonoBehaviour {

    public GameObject player;
    public GameObject mazeGenesys;

    // Start is called before the first frame update
    void Start() {
        player.SetActive(false);
        mazeGenesys.GetComponent<MazeGenerator>().GenerateMaze();
    }

    // Update is called once per frame
    void Update() {
        
    }
}
