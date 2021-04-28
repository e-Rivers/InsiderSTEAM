using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject DestroyedC;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            //Esconde moneda
            GetComponent<SpriteRenderer>().enabled = false;

            //Destruye moneda y animación
            Suma();
            Destroy(gameObject);
        }
    }

    void Suma()
    {
        DestroyedC.GetComponent<DestroyedCoins>().DestroyedC += 1;
    }
}
