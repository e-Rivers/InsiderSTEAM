using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballerIntroMover : MonoBehaviour
{

    // Private attributes
    private Transform tfm;
    private float speed;
    private bool isFirstTime;
    [SerializeField] Image dialogueBg;
    [SerializeField] DialogueConfirm dialogueScript;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip soundtrack;
    [SerializeField] Button skipButton;

    // Start is called before the first frame update
    void Start()
    {
        // Set framerate
        Application.targetFrameRate = 60;
        // Set initial variables
        tfm = GetComponent<Transform>();
        speed = 0.01f;
        isFirstTime = true;
        dialogueBg.enabled = false;
        dialogueScript.enabled = false;
        skipButton.GetComponent<Image>().enabled = false;
        skipButton.transform.GetChild(0).GetComponent<Text>().enabled = false;
        skipButton.enabled = false;
        StartCoroutine("MoveFireballerAround");
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag.Equals("DialogueTrigger"))
        {
            if (isFirstTime)
            {
                dialogueBg.enabled = true;
                dialogueScript.enabled = true;
                skipButton.GetComponent<Image>().enabled = true;
                skipButton.transform.GetChild(0).GetComponent<Text>().enabled = true;
                skipButton.enabled = true;
                audioSource.clip = soundtrack;
                audioSource.Play();
                isFirstTime = false;
            }
        }
    }

    IEnumerator MoveFireballerAround()
    {
        while (true)
        {
            if (tfm.position.y < 2.5f)
            {
                speed = 0.01f;
            }
            if (tfm.position.y > 3.5f)
            {
                speed = -0.01f;
            }
            tfm.position += new Vector3(0f, speed, 0f);
            yield return null;
        }
    }
}
