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
        audioSource = GameObject.Find("SoundSource").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Esconde moneda
            GetComponent<SpriteRenderer>().enabled = false;
            //Destruye moneda y animaci�n
            StartCoroutine("Suma");
        }
    }

    IEnumerator Suma()
    {
        audioSource.PlayOneShot(pickClip);
        DestroyedC.GetComponent<DestroyedCoins>().DestroyedC += 1;
        yield return null;
        Destroy(gameObject);
    }
}
