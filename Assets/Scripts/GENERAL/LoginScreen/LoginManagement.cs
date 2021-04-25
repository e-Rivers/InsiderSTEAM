using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;


public class LoginManagement : MonoBehaviour {

	public InputField userInput, passInput;
	public Text errorMessages;

	// When application starts verifies if the user is currently logged-in
	void Start() {
		if(PlayerPrefs.GetString("nickname") != "") SceneManager.LoadScene("MainMenu");
	}

    // Function called when button is pressed
	public void retrieveInput() {
		// Removes all spaces and Enters from the input fields
		string userText = userInput.text.Replace("\n", "").Replace("\r", "").Replace(" ","");
		string passText = passInput.text.Replace("\n", "").Replace("\r", "").Replace(" ","");
		// Validates that all input fields were filled
		if(userText == "" || passText == "") {
			errorMessages.text = "COMPLETA TODOS LOS CAMPOS.";
		} else {
			StartCoroutine(validateCredentials(userText, passText));
		}
	}
    
    // Coroutine funtion to validate the user given login credentials
	private IEnumerator validateCredentials(string userText, string passText) {
		// Creates the JSON POST form to validate given credentials
		WWWForm loginForm = new WWWForm();
		loginForm.AddField("nickname", userText);
		loginForm.AddField("password", passText);
		UnityWebRequest request = UnityWebRequest.Post("http://18.116.123.111:8080/insider/iniciarSesionUnity", loginForm);
		// Executes the request
		yield return request.SendWebRequest(); 
		// After the request has completed, checks if it was successful
		if(request.result == UnityWebRequest.Result.Success) {
			string returnMsg = request.downloadHandler.text;
			// Verifies the return message managed with Node.JS
			if(returnMsg == "WRONG CREDENTIALS") {
				errorMessages.text = "USUARIO O CONTRASEÑA INCORRECTOS.";
			} else if(returnMsg == "SUCCESS") {
				// If login was successful saves the credentials locally and displays the main menu
				PlayerPrefs.SetString("nickname", userText);
				PlayerPrefs.Save();				
				SceneManager.LoadScene("MainMenu");
			} else {
				errorMessages.text = "HUBO UN ERROR, INTENTA DE NUEVO.";
			}
		} else {
			errorMessages.text = "ERROR DE CONEXIÓN: " + request.responseCode.ToString();
		}
	}
	
	// Method to exit application
    public void exitGame() {
    	Application.Quit();
    }
}
