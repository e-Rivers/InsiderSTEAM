using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedaItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {   
            //Prende explosión
            gameObject.transform.GetChild(0).gameObject.SetActive(true);

            //Esconde moneda
            GetComponent<SpriteRenderer>().enabled = false;

            //Destruye moneda y animación
            Destroy(gameObject, t: 1f);
        }
    }
}
