using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;


public class LoginManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
		UnityWebRequest request = UnityWebRequest.Post("http://18.116.123.111:8080/insider/iniciarSesion", loginForm);
		// Executes the request
		yield return request.SendWebRequest(); 
		// After the request has completed, checks if it was successful
		if(request.result == UnityWebRequest.Result.Success) {
			string plainText = request.downloadHandler.text;
			// Since the GET method is retrieving a value from the database, if that value is empty it means that either
			// the username or password are incorrect
			
			Debug.Log(plainText);
			
			/*if(plainText=="[]") {
				errorMessages.text = "USUARIO O CONTRASEÑA INCORRECTOS.";
			} else {
				// If login was successful displays the main menu
				SceneManager.LoadScene("EscenaMenu");
			}*/
		} else {
			errorMessages.text = "ERROR DE CONEXIÓN: " + request.responseCode.ToString();
		}
	}
	
	// Method to exit application
    public void exitGame() {
    	Application.Quit();
    }
}
