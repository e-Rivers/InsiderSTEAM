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
    public GameObject player, mazeGenesys, initBanner, endsBanner, mazeCover, finishPanel, short1, short2, short3, holoIDLE, holoFAIL, pauseScreen, door;
    public Text timeText, roundText, askText, sciText, finishTitle, finishText;
    public AudioSource normalMusic, askingMusic, startingAlarm, collapseAudio, circuitAudio;
    public Image alarmLight;
    // Attributes that are used in other classes (MoveCharacter.cs)
    public static bool isAskTime = false;
    public static int roundType = 0; //(odd is labyrinth crossing & even is answering)
    // Internal attributes
    private Dictionary<string, string> riddleDict = new Dictionary<string, string>();
    private bool labyCrossed = false;
    private Coroutine subTime, alarmEffect, shortEffect, askSequence, doorActions;
    private int timeCount = 30, questionType, correctSeqAns;
    private string sidebarAns = "", endingAns = "", curSound, effect;
    private int[] sequence = new int[10];
    private List<int> savedTimestamps = new List<int>(); // This list holds the times it took to the user to solve each riddle and problem
    private float score;

    // Loads all riddles and problems
    void Start()
    {
		resetVars();
		alarmEffect = StartCoroutine(alarmScreenEffect());	
        riddleDict.Add("Son 28 caballeros de espaldas negras y lisas; delante, todo agujeros, por dominar se dan prisa.", "DOMINÓ");
        riddleDict.Add("Soy de madera, tengo un arco y no flecha.", "VIOLÍN");
        riddleDict.Add("Un oso camina 5 km al sur, 5 km al oeste y 5 km al norte. ¿De qué color es el oso?", "BLANCO");
        riddleDict.Add("¿Cuántos animales tengo en casa sabiendo que todos son perros menos dos, todos son gatos menos dos, y que todos son loros menos dos?", "3");
        riddleDict.Add("Está en dos abanicos que danzan todo el día; y cuando por fin te duermes quietecitos quedarán. Al caer una, tus deseos cumplirá.", "PESTAÑA");
        riddleDict.Add("Si 5 máquinas hacen 5 artículos en 5 minutos, ¿cuántos minutos dedicarán 100 máquinas en hacer 100 artículos?", "5");
        riddleDict.Add("Un león muerto de hambre, ¿de qué se alimenta?", "NADA");
        riddleDict.Add("Este banco está ocupado por un padre y por un hijo: El padre se llama Juan y el hijo ya te lo he dicho.", "ESTEBAN");
        riddleDict.Add("Si me tienes, quieres compartirme; si me compartes, no me tienes. ¿Qué soy?", "SECRETO");
        riddleDict.Add("Ponme de lado y todo soy, córtame por la mitad y no soy nada. ¿Qué soy?", "8");
        riddleDict.Add("¿Qué animal tiene los pies en la cabeza?", "PIOJO");
        riddleDict.Add("No muerde ni ladra, pero la casa guarda, ¿Qué es?", "LLAVE");
        riddleDict.Add("¿Cuál es el ave que tiene la panza llana?", "AVELLANA");
        riddleDict.Add("No es más grande que una nuez, sube al monte y no tiene pies, ¿Qué es?", "CARACOL");
        riddleDict.Add("Es tan largo como un camino, y gruñe como un cochino.", "RÍO");   
        riddleDict.Add("Es blanco como la sal, sumamente sencillo de abrir pero imposible de cerrar. ¿Qué es?", "HUEVO");           
        riddleDict.Add("Grande, muy grande, mayor que la Tierra. Arde y no se quema, quema y no es candela.", "SOL");     
        riddleDict.Add("20 patos caminaban, los 20 con una pata y no más. ¿Cuántas patas tocaban el suelo?", "42");     
        riddleDict.Add("Es tuyo pero todos lo usan más, ¿Qué es?", "NOMBRE");
        riddleDict.Add("Se repite una vez en el minuto, dos en el momento pero nunca en el año. ¿Qué es?", "M");  
        riddleDict.Add("¿Dónde es posible encontrar el jueves antes que el miércoles?", "DICCIONARIO");
        riddleDict.Add("Es tan delicado, que si lo mencionas se rompe y deja de existir. ¿Qué es?", "SILENCIO");
        riddleDict.Add("Entre cielo y tierra estoy, ¿Qué soy?", "Y");
        riddleDict.Add("Posee un hambre insaciable y al comer crece, pero al beber desaparece. ¿Qué es?", "FUEGO");
        riddleDict.Add("Tengo calor y frío, pero no frio sin calor, y aún sin ser mar ni río, peces he tenido, ¿Qué soy?", "SARTÉN");
        riddleDict.Add("Un hombre tiene cinco hijos, cada uno tiene una hermana, ¿cuántos hijos tiene el hombre?", "6");
        riddleDict.Add("¿Qué tiene la capacidad de retener agua aún teniendo múltiples agujeros?", "ESPONJA");
        riddleDict.Add("¿Qué palabra acortas si le agregas dos letras?", "CORTA");
        riddleDict.Add("Tiene cuello pero no cabeza. ¿Qué es?", "BOTELLA");
        riddleDict.Add("Tiene patas, carga cosas, pero no camina. ¿Qué es?", "MESA");   
		riddleDict.Add("¿Qué es que tiene dientes pero no muerde?", "PEINE");
		riddleDict.Add("¿Qué tiene bosques sin tener árboles, mares sin tener agua y desiertos sin arena?", "MAPA");
		riddleDict.Add("Sólo puede existir en presencia de luz, pero si la luz le ilumina, pierde su vida. ¿Qué es?", "SOMBRA");
		riddleDict.Add("Repito lo que dices, pero entre más lo repito, más quedito lo digo. ¿Qué soy?", "ECO");
		riddleDict.Add("Si le arrancas la piel, no sufrirá ni le dolerá, mas tú llorarás.", "CEBOLLA");
		riddleDict.Add("¿Qué letras siguen la secuencia: UTTFCS?", "SEN");
		riddleDict.Add("Una niña tiene 30 años menos que su padre y siendo que la suma de sus edades es 36, ¿qué edad tiene ella?", "3");
		riddleDict.Add("No soy de carne y huevo, no estoy vivo pero tengo 5 dedos ¿Qué soy?", "GUANTE");
		riddleDict.Add("El que lo hace lo vende, el que lo compra no lo usa y el que lo usa, jamás lo ve. ¿Qué es?", "ATAÚD");
		riddleDict.Add("¿Pesa más un kilo de hierro o uno de paja?", "IGUAL");
		riddleDict.Add("Si sube, nos vamos, si baja, nos quedamos.", "ANCLA");
		riddleDict.Add("Tengo llaves pero no cerradura, el negro y el blanco pasan por mi cintura.", "KARATE");
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
	// Detects if the user paused the game
	if(Input.GetKeyDown(KeyCode.Escape) && (roundType%2 != 0 || initBanner.activeSelf)) alterElements("pause");
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
			// ======== Selects between a riddle or problem
			// ##################################################################################################################
			questionType = 0; //(int) Random.Range(0, 3);
			if(questionType == 0) {
				int randomSelection = (int) Random.Range(0, riddleDict.Keys.Count);
				string randomRiddle = riddleDict.Keys.ElementAt(randomSelection);
				askText.text = randomRiddle;
			} else {
				StopCoroutine(subTime);
				askSequence = StartCoroutine(sequenceMemory());
			}
			doorActions = StartCoroutine(doorSystem("CLOSE"));
            sciText.text = "Algunos accesos se bloquearon, para abrirlos responde la pregunta...";
	    	normalMusic.Stop();
            askingMusic.Play();
        }
    }

    // Method that implements the logic to ask questions and validate the answer
    private void askRiddleOrProblem()
    {
		void onCorrectAnswer() {
			doorActions = StartCoroutine(doorSystem("OPEN"));
			askText.text = ""; 
	        sidebarAnswer.text = "";
	        sidebarAns = "";
	        mazeCover.SetActive(false);
	        //mazeGenesys.GetComponent<MazeGenerator>().DeleteMaze();     // Probably removed in further versions
	        //mazeGenesys.GetComponent<MazeGenerator>().GenerateMaze();   // due to difficulty
			// Saves the time
			savedTimestamps.Add(timeCount);
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
        if (timeCount >= 0)
        {
            timeText.text = "Tiempo: " + timeCount;
			if(questionType == 0) {
		            if (sidebarAns == riddleDict[askText.text])
		            { 
						onCorrectAnswer();
		            } else if(sidebarAns != "") sciText.text = "INCORRECTO! Intenta de nuevo... Se nos acaba el tiempo!!";
			} else {
			if(sidebarAns == correctSeqAns.ToString()) {
				onCorrectAnswer();
			} else if(sidebarAns != "") sciText.text = "INCORRECTO! Rápido! Debemos apagar el reactor antes que sea tarde!";
			}
        }
        else
        {
	    alterElements("");
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
			int randomEffect = (int) Random.Range(0, 11);
			switch(randomEffect) {
			case 2:
				short1.SetActive(true); 
				circuitAudio.Play();
				break;
			case 8:
				short2.SetActive(true); 
				circuitAudio.Play();
				break;
			case 6:
				short3.SetActive(true); 
				circuitAudio.Play();
				break;
			case 4:
				collapseAudio.Play(); 
				ArtCameraShake.instance.ShakeCamera(0.3f,0.5f);
				break;
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
    
    // Coroutine to open and close the doors
    private IEnumerator doorSystem(string action) {
    	if(action == "CLOSE") {
    		for(float i = 11; i >= 0; i--) {
    			door.transform.position = new Vector3(0, i, 0);
    			yield return new WaitForSeconds(0.05f);
    		}
    	} else {
    		for(float i = 0; i <= 11; i++) {
    			door.transform.position = new Vector3(0, i, 0);
    			yield return new WaitForSeconds(0.05f);
    		}
    	}
    	
    }

    // Coroutine to generate the sequence problems
    private IEnumerator sequenceMemory() {
		askText.text = "Presta atención a la siguiente secuencia:";
		for(int i = 0; i < 10; i++) {
		    int randyNum = (int) Random.Range(0,100);
			sequence[i] = randyNum;
		}
		int correctIndex = (int) Random.Range(0, 10);
		correctSeqAns = sequence[correctIndex];
		yield return new WaitForSeconds(5);
		foreach(int a in sequence) {
			askText.text = a.ToString();
			yield return new WaitForSeconds(0.75f);
		}
		askText.text = "¿Cuál era el número en la " + (correctIndex+1).ToString() + "° posición?";
		subTime = StartCoroutine(reduceTimer());
    } 

    // Method to verify if the player escaped and to ask for the last question
    private void verifyEscapeAndEnding()
    {
        // Checks if the player is out of the labyrinth borders
        if (player.transform.position.x >= 4.5 || player.transform.position.x <= -4.5 || player.transform.position.y >= 4.5 || player.transform.position.y <= -4.5)
        {
            if (!labyCrossed)
            {
		alterElements("");
                timeCount = 60;
                labyCrossed = true;
                sciText.text = ". . .";
                askingMusic.Play();
		endsBanner.SetActive(true);
            }
            timeText.text = "Tiempo: " + timeCount;
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
    	
    	score = calculateScore();
    	Debug.Log("Final: " + score);
    	//SendingDataPrompt.instance.SetPrompt(1024, 1, "MainMenu");
    }

    // Method to play again
    public void playAgain() {
		MenuManager.nextScene = "ScienceLevel";
		SceneManager.LoadScene(MenuManager.nextScene);
    }

    // Method to resume game
    public void resumeGame() { alterElements("unpause"); }

    // Method to display, destroy or hide game and UI objects
    private void alterElements(string action) {
		if(action == "pause") {
			if(!initBanner.activeSelf) MazeGenerator.mazeParent.SetActive(false);
			pauseScreen.SetActive(true);
			Time.timeScale = 0;
			// Pauses the currently active Music
			if(normalMusic.isPlaying) {
				curSound = "normal";
				normalMusic.Pause();
			} else if(startingAlarm.isPlaying) {
				curSound = "alarm";
				startingAlarm.Pause();
			}
			// Pauses the currently active effect
			if(short1.activeSelf) {
				effect = "short1";
				circuitAudio.Pause();
				short1.GetComponent<SpriteRenderer>().sortingOrder = -100;
			} else if(short2.activeSelf) {
				effect = "short2";
				circuitAudio.Pause();
				short2.GetComponent<SpriteRenderer>().sortingOrder = -100;
			} else if(short3.activeSelf) {
				effect = "short3";
				circuitAudio.Pause();
				short3.GetComponent<SpriteRenderer>().sortingOrder = -100;
			} else {
				effect = "collapse";
				collapseAudio.Pause();
			}
			// Pauses the hologram animation
			holoIDLE.GetComponent<SpriteRenderer>().sortingOrder = -100;
		} else if(action == "unpause") {
			if(!initBanner.activeSelf) MazeGenerator.mazeParent.SetActive(true);
			pauseScreen.SetActive(false);
			Time.timeScale = 1;
			// Reactivates the adecuate Music
			if(curSound == "normal") normalMusic.UnPause();
			else startingAlarm.UnPause();
			// Reactivates the hologram animation
			holoIDLE.GetComponent<SpriteRenderer>().sortingOrder = 0;
			player.SetActive(true);
			door.SetActive(true);
			// Reactivates the last active effect
			if(effect == "short1") {
				circuitAudio.UnPause();
				short1.GetComponent<SpriteRenderer>().sortingOrder = -1;
			} else if(effect == "short2") {
				circuitAudio.UnPause();
				short2.GetComponent<SpriteRenderer>().sortingOrder = 0;
			} else if(effect == "short3") {
				circuitAudio.UnPause();
				short3.GetComponent<SpriteRenderer>().sortingOrder = 0;
			} else {
				collapseAudio.UnPause();
			}
			return;
		} else {
			StopCoroutine(shortEffect);
		    mazeGenesys.GetComponent<MazeGenerator>().DeleteMaze();
			normalMusic.Stop();
			askingMusic.Stop();
			collapseAudio.Stop();
			circuitAudio.Stop();
			short1.SetActive(false);
			short2.SetActive(false);
			short3.SetActive(false);
			holoIDLE.SetActive(false);
		}
		mazeCover.SetActive(false);
		player.SetActive(false);
		holoFAIL.SetActive(false);
		door.SetActive(false);
    }

    // Method to reset all the control variables to their initial values
    private void resetVars() {
		isAskTime = false;
		roundType = 0;
		labyCrossed = false;
		timeCount = 30;
		sidebarAns = "";
		endingAns = "";
    }
    
    private float calculateScore() {
    	float finalScore = 0, answerTimeRateSum = 0;
    	string[] prevRound = roundText.text.Split(' ');
	    finalScore += (-10 * (roundType - int.Parse(prevRound[1])));
       	Debug.Log("Round part: " + finalScore);
	    foreach(int i in savedTimestamps) {
	    	answerTimeRateSum += (float) (1/(60-i))*500;
	    }
	    if(savedTimestamps.Count != 0) {
	    	Debug.Log("Timestamps: " + (answerTimeRateSum/savedTimestamps.Count));
	    	finalScore += (float) (answerTimeRateSum/savedTimestamps.Count);
	    }
	    return finalScore;
    }

}

















