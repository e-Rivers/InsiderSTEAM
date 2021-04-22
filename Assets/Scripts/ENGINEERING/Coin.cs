using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            //Esconde moneda
            GetComponent<SpriteRenderer>().enabled = false;

            //Destruye moneda y animación
            Destroy(gameObject, t: 1f);
        }
    }
}
