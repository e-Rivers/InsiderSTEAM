using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EngHUD : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] Text coinText;

    private string finalStringPart;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0 pts.";
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level 1":
                finalStringPart = "/7";
                break;
            case "Level 2":
                finalStringPart = "/9";
                break;
            case "Level 3":
                finalStringPart = "/9";
                break;
        }
        StartCoroutine("TextAnimation");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreText.text = ScoreE.instance.finalScore + " pts";
        coinText.text = DestroyedCoins.instance.DestroyedC.ToString() + finalStringPart;
    }

    // Score text animation coroutine
    IEnumerator TextAnimation()
    {
        while (true)
        {
            while (scoreText.rectTransform.localPosition.y < 500)
            {
                scoreText.rectTransform.localPosition += new Vector3(0f, 0.5f, 0f);
                yield return null;
            }
            while (scoreText.rectTransform.localPosition.y > 475)
            {
                scoreText.rectTransform.localPosition -= new Vector3(0f, 0.5f, 0f);
                yield return null;
            }
        }
    }

}
