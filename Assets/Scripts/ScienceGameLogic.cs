using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScienceGameLogic : MonoBehaviour {

    public static int roundType = 0; //(odd is labyrinth crossing & even is answering)
    private int timeCount = 20;
    public GameObject player, mazeGenesys, initBanner, mazeCover;
    public Text timeText;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        // Checks if the user clicked to remove the banner to start the game
        if(!initBanner.activeSelf && roundType == 0) {
            mazeGenesys.GetComponent<MazeGenerator>().GenerateMaze();
            player.SetActive(true);
            roundType++;
        } else if(roundType%2 != 0) {
            roundTypeMEM();
        } else if(roundType != 0 && roundType%2 == 0) {
            roundTypeACT();
        }
    }

    // Method that implements the memorizing time
    private void roundTypeMEM() {
        if(timeCount >= 0) {
            timeText.text = "Tiempo: " + timeCount;
            int lastTime = System.DateTime.Now.Second;
            while(System.DateTime.Now.Second == lastTime);
            timeCount -= 1;
        } else { 
            timeCount = 20;
            roundType++;
        }
    }

    // Method that implements the labyrinth crossing time
    private void roundTypeACT() {
        if(timeCount >= 0) {
            mazeCover.SetActive(true);
            timeText.text = "Tiempo: " + timeCount;
            int lastTime = System.DateTime.Now.Second;
            while(System.DateTime.Now.Second == lastTime);
            timeCount -= 1;
        } else {
            mazeCover.SetActive(false);
            mazeGenesys.GetComponent<MazeGenerator>().DeleteMaze();
            mazeGenesys.GetComponent<MazeGenerator>().GenerateMaze();
            timeCount = 20;
            roundType++;
        }
    }
}














