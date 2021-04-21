using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropColor : MonoBehaviour
{
    // Public attributes
    public GameObject artCanvas;
    private bool canPlaceDrop = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!PlayerMovement.instance.disableInput)
            {
                if (canPlaceDrop)
                {
                    ArtCanvasCollector.instance.TryAddColor(ColorSystem.instance.currentColor.GetComponent<ColorBehaviour>().identifier);
                    ArtScoreSystem.instance.AddPoints(ArtCanvasCollector.instance.correct);
                    canPlaceDrop = false;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.CompareTag("ArtCanvas"))
        {
            canPlaceDrop = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("ArtCanvas"))
        {
            canPlaceDrop = false;
        }
    }

}
