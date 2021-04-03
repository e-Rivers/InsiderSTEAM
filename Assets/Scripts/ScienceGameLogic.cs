using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ScienceGameLogic : MonoBehaviour {

    public static int roundType = 0; //(odd is labyrinth crossing & even is answering)
    private int timeCount = 20;
    public GameObject player, mazeGenesys, initBanner, endsBanner, mazeCover;
    public Text timeText, roundText, askText, sciText;
    public InputField endsBannerAnswer, sidebarAnswer;
    private Dictionary<string, string> riddleDict = new Dictionary<string, string>();    
    private bool isAskTime = false, labyCrossed = false;
    private Coroutine subTime;

    // Loads all riddles and problems
    void Start() {
        riddleDict.Add("Un oso camina 5 km al sur, 5 km al oeste y 5 km al norte. ¿De qué color es el oso?", "BLANCO");
        riddleDict.Add("¿Cuántos animales tengo en casa sabiendo que todos son perros menos dos, todos son gatos menos dos, y que todos son loros menos dos?", "3");
        riddleDict.Add("Si 5 máquinas hacen 5 artículos en 5 minutos, ¿cuántos minutos dedicarán 100 máquinas en hacer 100 artículos?", "5");
        riddleDict.Add("Un león muerto de hambre, ¿de qué se alimenta?", "NADA");
        riddleDict.Add("Este banco está ocupado por un padre y por un hijo: El padre se llama Juan y el hijo ya te lo he dicho.", "ESTEBAN");
        riddleDict.Add("Si me tienes, quieres compartirme; si me compartes, no me tienes. ¿Qué soy?", "SECRETO");
        riddleDict.Add("Ponme de lado y todo soy, córtame por la mitad y no soy nada. ¿Qué soy?", "8");
        riddleDict.Add("¿Qué animal tiene los pies en la cabeza?", "PIOJO");
    }

    // Update is called once per frame
    void Update() {
        if(!labyCrossed) {
            // Checks if the user clicked to remove the banner to start the game
            if(!initBanner.activeSelf && roundType == 0) {
                subTime = StartCoroutine(reduceTimer());
                mazeGenesys.GetComponent<MazeGenerator>().GenerateMaze();
                player.SetActive(true);
                roundType++;
            } else if(roundType%2 != 0) {
                roundTypeMEM();
            } else if(roundType != 0 && roundType%2 == 0) {
                if(!isAskTime) { roundTypeACT(); } else { askRiddleOrProblem(); }
            }
        }
        // Checks if the player has escaped the labyrinth
        verifyEscapeAndEnding(); 
    }

    // Method that implements the memorizing time
    private void roundTypeMEM() {
        if(timeCount >= 0) {
            timeText.text = "Tiempo: " + timeCount;
            sciText.text = "Veamos que tanto puedes memorizar del laberinto...";
        } else { 
            timeCount = 20;
            roundType++;
        }
    }

    // Method that implements the labyrinth crossing time
    private void roundTypeACT() {
        if(!isAskTime && timeCount >= 0) {
            mazeCover.SetActive(true);
            timeText.text = "Tiempo: " + timeCount;
            sciText.text = "Este es el momento... crúzalo con lo que recuerdes...";
        } else {
            isAskTime = true;
            timeCount = 10;
            int randomSelection = Random.Range(0, riddleDict.Keys.Count);
            string randomRiddle = riddleDict.Keys.ElementAt(randomSelection);
            askText.text = randomRiddle;
            sciText.text = "Si quieres pasar de ronda... contesta mi pregunta...";
        }
    }
    
    // Method that implements the logic to ask questions and validate the answer
    private void askRiddleOrProblem() {
        if(timeCount >= 0) {
            timeText.text = "Tiempo: " + timeCount;
            if(ScienceCanvasOperations.sidebarAns == riddleDict[askText.text]) {
                askText.text = "";
                mazeCover.SetActive(false);
                mazeGenesys.GetComponent<MazeGenerator>().DeleteMaze();
                mazeGenesys.GetComponent<MazeGenerator>().GenerateMaze();                
                // Calculates the current round
                roundType++;
                string[] prevRound = roundText.text.Split(' ');
                roundText.text = "Ronda: " + (roundType-int.Parse(prevRound[1]));
                timeCount = 20;            
                isAskTime = false;           
            } else {
                if(ScienceCanvasOperations.sidebarAns != "") {
                    sciText.text = "INCORRECTO! Intenta de nuevo... si es que te alcanza el tiempo...";
                }
            }
        } else {
            Debug.Log("PERDISTE FRACASADO!");
        }
    }

    // Method to update substract one to the timer
    IEnumerator reduceTimer() {
        while(true) {
            yield return new WaitForSeconds(1);
            timeCount--; 
        }
    }

    // Method to verify if the player escaped and to ask for the last question
    private void verifyEscapeAndEnding() {
         // Checks if the player is out of the labyrinth borders
        if(player.transform.position.x >= 4.5 || player.transform.position.x <= -4.5 || player.transform.position.y >= 4.5 || player.transform.position.y <= -4.5) {
            if(!labyCrossed) {
                timeCount = 60;
                labyCrossed = true;
            }
            timeText.text = "Tiempo: " + timeCount;
            mazeGenesys.GetComponent<MazeGenerator>().DeleteMaze();
            mazeCover.SetActive(false);
            player.SetActive(false);
            endsBanner.SetActive(true);
            if(timeCount > 0) {
                if(ScienceCanvasOperations.endingAns == "1") {
                    StopCoroutine(subTime);
                    Debug.Log("LO HICISTE BIEN, GANADOR!");
                }
            } else {
                StopCoroutine(subTime);
                Debug.Log("PERDISTE!");
            }
        }
    }  
}












