using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostScores : MonoBehaviour
{
    public static void postRequest(int score, int worldId, string nextScene) 
    {
    	// Creates the JSON POST form to register user score
		WWWForm scoreForm = new WWWForm();
		scoreForm.AddField("end_date", System.DateTime.Now.ToString("yyyy-MM-dd"));
		scoreForm.AddField("score", score);
		scoreForm.AddField("worldId", worldId);
		scoreForm.AddField("playerNickname", PlayerPrefs.GetString("nickname"));
		UnityWebRequest request = UnityWebRequest.Post("http://18.116.123.111:8080/insider/nuevaPartida", scoreForm);
		// Sends the request
		request.SendWebRequest();
		
		SendingDataPrompt.instance.RemovePrompt();		
		
		/*SendingDataPrompt.RemoveContainer();
		
		// Makes the transtition to the corresponding scene
		MenuManager.nextScene = nextScene;
		MenuManager.instance.EnterScene(false);*/
		
		/*if(passLoadingScene) {
			SceneManager.LoadScene("LoadingScene");
		} else {
			SceneManager.LoadScene(MenuManager.nextScene);
		}*/
    }
}






