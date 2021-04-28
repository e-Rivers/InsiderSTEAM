using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Networking;


public class PostScores : MonoBehaviour
{
    public static void postRequest(int score, int worldId) 
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
			Debug.Log(returnMsg);
		} else {
			Debug.Log(request.responseCode.ToString());
		}
    }
}
