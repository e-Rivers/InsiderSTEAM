using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json;


public class LoginManagement : MonoBehaviour {

	public InputField userInput, passInput;
	public Text errorMessages;
	public Image errorPanel;
	public Button submit;

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
		// Sets the URI to where the request is going to be sent
		string URLresource = "http://18.116.123.111:8080/" + userText + "/" + passText;
		UnityWebRequest request = UnityWebRequest.Get(URLresource);
		// Executes the request
		yield return request.SendWebRequest(); 
		// After the request has completed, checks if it was successful
		if(request.result == UnityWebRequest.Result.Success) {
			string plainText = request.downloadHandler.text;
			// Since the GET method is retrieving a value from the database, if that value is empty it means that either
			// the username or password are incorrect
			if(plainText=="[]") {
				errorMessages.text = "USUARIO O CONTRASEÑA INCORRECTOS.";
			} else {
				// If login was successful displays the main menu
				SceneManager.LoadScene("EscenaMenu");
			}
		} else {
			errorMessages.text = "ERROR DE CONEXIÓN: " + request.responseCode.ToString();
		}
	}
}
