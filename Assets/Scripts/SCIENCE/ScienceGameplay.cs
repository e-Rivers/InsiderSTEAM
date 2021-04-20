using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class ScienceGameplay : MonoBehaviour
{

    // Attibutes that aren't used in other classes but their values are obtained publicly
    public InputField regInput, endInput, endsBannerAnswer, sidebarAnswer;
    public GameObject player, mazeGenesys, initBanner, endsBanner, mazeCover, finishPanel, short1, short2, short3, holoIDLE, holoFAIL;
    public Text timeText, roundText, askText, sciText, finishTitle, finishText;
    public AudioSource normalMusic, askingMusic, startingAlarm, collapseAudio, circuitAudio;
    public Image alarmLight;
    // Attributes that are used in other classes (MoveCharacter.cs)
    public static bool isAskTime = false;
    public static int roundType = 0; //(odd is labyrinth crossing & even is answering)
    // Internal attributes
    private Dictionary<string, string> riddleDict = new Dictionary<string, string>();
    private bool labyCrossed = false;
    private Coroutine subTime, alarmEffect, shortEffect;
    private int timeCount = 30;
    private string sidebarAns = "", endingAns = "";

    // Loads all riddles and problems
    void Start()
    {
	alarmEffect = StartCoroutine(alarmScreenEffect());	
        riddleDict.Add("Son 28 caballeros de espaldas negras y lisas; delante, todo agujeros, por dominar se dan prisa.", "DOMINO");
        riddleDict.Add("Soy de madera, tengo un arco y no flecha.", "VIOLIN");
        riddleDict.Add("Un oso camina 5 km al sur, 5 km al oeste y 5 km al norte. ¿De qué color es el oso?", "BLANCO");
        riddleDict.Add("¿Cuántos animales tengo en casa sabiendo que todos son perros menos dos, todos son gatos menos dos, y que todos son loros menos dos?", "3");
        riddleDict.Add("Dos abanicos que danzan todo el día sin parar; y cuando por fin te duermas quietecitos quedarán. Al caer tus deseos cumplirán.", "PESTAÑAS");
        riddleDict.Add("Si 5 máquinas hacen 5 artículos en 5 minutos, ¿cuántos minutos dedicarán 100 máquinas en hacer 100 artículos?", "5");
        riddleDict.Add("Un león muerto de hambre, ¿de qué se alimenta?", "NADA");
        riddleDict.Add("Este banco está ocupado por un padre y por un hijo: El padre se llama Juan y el hijo ya te lo he dicho.", "ESTEBAN");
        riddleDict.Add("Si me tienes, quieres compartirme; si me compartes, no me tienes. ¿Qué soy?", "SECRETO");
        riddleDict.Add("Ponme de lado y todo soy, córtame por la mitad y no soy nada. ¿Qué soy?", "8");
        riddleDict.Add("¿Qué animal tiene los pies en la cabeza?", "PIOJO");
    }

    // Update is called once per frame
    void Update()
    {
        if (!labyCrossed)
        {
            // Checks if the user clicked to remove the banner to start the game
            if (!initBanner.activeSelf && roundType == 0)
            {
		holoIDLE.SetActive(true);
		shortEffect = StartCoroutine(shortCircuitEffect());
		alarmLight.gameObject.SetActive(false);
		StopCoroutine(alarmEffect);
		startingAlarm.Stop();
                subTime = StartCoroutine(reduceTimer());
                mazeGenesys.GetComponent<MazeGenerator>().GenerateMaze();
                player.SetActive(true);
                roundType++;
                normalMusic.Play();
            }
            else if (roundType % 2 != 0)
            {
                roundTypeMEM();
            }
            else if (roundType != 0 && roundType % 2 == 0)
            {
                if (!isAskTime) { roundTypeACT(); } else { askRiddleOrProblem(); }
            }
        }
        // Checks if the player has escaped the labyrinth
        verifyEscapeAndEnding();
    }

    // Method that implements the memorizing time
    private void roundTypeMEM()
    {
        if (timeCount >= 0)
        {
            timeText.text = "Tiempo: " + timeCount;
            sciText.text = "Memoriza el laberinto, porque al terminar el tiempo, deberás cruzarlo...";
        }
        else
        {
            timeCount = 20;
            roundType++;
	    holoIDLE.SetActive(false);
	    holoFAIL.SetActive(true);
        }
    }

    // Method that implements the labyrinth crossing time
    private void roundTypeACT()
    {
        if (!isAskTime && timeCount >= 0)
        {
            mazeCover.SetActive(true);
            timeText.text = "Tiempo: " + timeCount;
            sciText.text = "Ahora sí, usa las flechas o WASD para cruzarlo con lo que recuerdes...";
        }
        else
        {
            isAskTime = true;
            timeCount = 60;
            int randomSelection = Random.Range(0, riddleDict.Keys.Count);
            string randomRiddle = riddleDict.Keys.ElementAt(randomSelection);
            askText.text = randomRiddle;
            sciText.text = "Algunos accesos se bloquearon, para abrirlos resuelve el acertijo...";
            askingMusic.Play();
        }
    }

    // Method that implements the logic to ask questions and validate the answer
    private void askRiddleOrProblem()
    {
        if (timeCount >= 0)
        {
            timeText.text = "Tiempo: " + timeCount;
            if (sidebarAns == riddleDict[askText.text])
            {
                askText.text = "";
                sidebarAnswer.text = "";
                sidebarAns = "";
                mazeCover.SetActive(false);
                mazeGenesys.GetComponent<MazeGenerator>().DeleteMaze();
                mazeGenesys.GetComponent<MazeGenerator>().GenerateMaze();
                // Calculates the current round
                roundType++;
                string[] prevRound = roundText.text.Split(' ');
                roundText.text = "Ronda: " + (roundType - int.Parse(prevRound[1]));
                timeCount = 30;
                isAskTime = false;
                askingMusic.Stop();
                normalMusic.Play();
		holoFAIL.SetActive(false);
		holoIDLE.SetActive(true);
            }
            else if (sidebarAns != "")
            {
                sciText.text = "INCORRECTO! Intenta de nuevo... Se nos acaba el tiempo!!";
            }
        }
        else
        {
            askingMusic.Stop();
            StopCoroutine(subTime);
            finishTitle.text = "DERROTA";
            finishText.text = "No lograste desactivar el reactor, pero no te rindas, entrena tu mente, piensa creativamente y verás como irás mejorando hasta que por fin la victoria sea tuya.";
            finishPanel.SetActive(true);
        }
    }

    // Method to update substract one to the timer
    private IEnumerator reduceTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeCount--;
        }
    }

    // Coroutine to display the short-circuit effects
    private IEnumerator shortCircuitEffect() {
	while(true) {
	    int randomEffect = (int) Random.Range(0f, 10f);
	    switch(randomEffect) {
		case 2:
		    short1.SetActive(true); 
		    circuitAudio.Play();
		    break;
		case 4:
		    short2.SetActive(true); 
		    circuitAudio.Play();
		    break;
		case 6:
		    short3.SetActive(true); 
		    circuitAudio.Play();
		    break;
		case 8:
		    collapseAudio.Play(); break;
	    }
	    yield return new WaitForSeconds(5);
	    short1.SetActive(false);
	    short2.SetActive(false);
	    short3.SetActive(false);
	}
    }

    // Coroutine to display the alarm effect
    private IEnumerator alarmScreenEffect() {
	while(true) {
	    alarmLight.canvasRenderer.SetAlpha(0);
	    alarmLight.CrossFadeAlpha(0.7f,0.5f,false);
	    yield return new WaitForSeconds(0.5f);
	    alarmLight.CrossFadeAlpha(0,0.5f,false);
	    yield return new WaitForSeconds(0.5f);
	}
    } 

    // Method to verify if the player escaped and to ask for the last question
    private void verifyEscapeAndEnding()
    {
        // Checks if the player is out of the labyrinth borders
        if (player.transform.position.x >= 4.5 || player.transform.position.x <= -4.5 || player.transform.position.y >= 4.5 || player.transform.position.y <= -4.5)
        {
            if (!labyCrossed)
            {
		StopCoroutine(shortEffect);
                timeCount = 60;
                labyCrossed = true;
                sciText.text = ". . .";
                normalMusic.Stop();
                askingMusic.Play();
            }
            timeText.text = "Tiempo: " + timeCount;
            mazeGenesys.GetComponent<MazeGenerator>().DeleteMaze();
            mazeCover.SetActive(false);
            player.SetActive(false);
            endsBanner.SetActive(true);
            if (timeCount > 0)
            {
                if (endingAns == "1")
                {
                    askingMusic.Stop();
                    StopCoroutine(subTime);
                    finishTitle.text = "VICTORIA";
                    finishText.text = "Tu memoria y habilidad mental son ADMIRABLES!! Haz conseguido salvar la nave y a sus científicos! Siéntete orgulloso, no cualquiera logra superar esto.";
                    finishPanel.SetActive(true);
                }
            }
            else
            {
                askingMusic.Stop();
                StopCoroutine(subTime);
                finishTitle.text = "DERROTA";
                finishText.text = "Muy bien jugado, lograste llegar lejos, sin embargo, esta vez has sido derrotado, enorgullécete y vuelve a intentarlo... más fuerte, más rápido y más inteligente.";
                finishPanel.SetActive(true);
            }
        }
    }

    // This method will remove the initial banner
    public void removeBanner()
    {
        initBanner.SetActive(false);
    }

    // Method to capture user input in every round
    public void captureRegInput()
    {
        sidebarAns = regInput.text.Replace("\n", "").Replace("\r", "").Replace(" ", "").ToUpper();
    }

    // Method to capture user input at the end of the game
    public void captureEndInput()
    {
        endingAns = endInput.text.Replace("\n", "").Replace("\r", "").Replace(" ", "").ToUpper();
    }

    // Method to return to main world
    public void returnToWorld()
    {
        MenuManager.nextScene = "MainMenu";
        SceneManager.LoadScene("LoadingScene");
    }
}
