using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostScores : MonoBehaviour
{
	static bool waitTime;
	
    public static void postRequest(int score, int worldId, string nextScene, bool passLoadingScene = true) 
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
		// After the request has completed, checks if it was successful
		if(request.result == UnityWebRequest.Result.Success) {
			string returnMsg = request.downloadHandler.text;
			if(returnMsg == "SUCCESS") {
//				uploadBanner;
			} else {
			
			}
		} else {
			Debug.Log(request.responseCode.ToString());
		}
		//StartCoroutine(WaitSomeTime());
		MenuManager.nextScene = nextScene;
		if(passLoadingScene) {
			SceneManager.LoadScene("LoadingScene");
		} else {
			SceneManager.LoadScene(MenuManager.nextScene);
		}
    }
    
    
    static IEnumerator WaitSomeTime() {
    	yield return new WaitForSeconds(2);
    }
}
