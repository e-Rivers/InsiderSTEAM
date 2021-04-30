using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject DestroyedC;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip pickClip;

    void Awake()
    {
        // Find audio source
        audioSource = GameObject.Find("SoundSource").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Play pickup sound
            audioSource.PlayOneShot(pickClip);
            // Increment destroyed coins counter
            DestroyedC.GetComponent<DestroyedCoins>().DestroyedC += 1;
            // Add coin value to score
            ScoreE.instance.AddScore(100, EngAnswerTimer.instance.coinTimer);
            // Reset coin-grabbing multiplier timer
            EngAnswerTimer.instance.ResetCoinTimer();
            // Destroy gameObject
            Destroy(gameObject);
        }
    }
}
