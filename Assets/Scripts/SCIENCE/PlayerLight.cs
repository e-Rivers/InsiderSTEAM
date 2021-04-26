using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLight : MonoBehaviour
{

    public Image battery1, battery2, battery3, battery4, battery5;
    public GameObject lights;
    private int batCount;
    private bool isActive;
    private Coroutine lightsOn;
    private SpriteRenderer spriteRenderer;
    private float alpha;

    // Start is called before the first frame update
    void Start()
    {
        batCount = 5;
        isActive = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (batCount > 0 && Input.GetKeyDown(KeyCode.Space) && !isActive && ScienceGameplay.roundType % 2 == 0 && !ScienceGameplay.isAskTime)
        {
            batCount--;
            switch (batCount)
            {
                case 0:
                    battery1.gameObject.SetActive(false);
                    break;
                case 1:
                    battery2.gameObject.SetActive(false);
                    break;
                case 2:
                    battery3.gameObject.SetActive(false);
                    break;
                case 3:
                    battery4.gameObject.SetActive(false);
                    break;
                case 4:
                    battery5.gameObject.SetActive(false);
                    break;
            }
            isActive = true;
            lightsOn = StartCoroutine(lightsActive());
        }
    }

    // Coroutine to light the player up and blink
    private IEnumerator lightsActive()
    {
        spriteRenderer.sortingOrder = 4;
        lights.SetActive(true);
        for (int i = 0; i < 2; i++)
        {
            alpha = 0;
            while (alpha < 1)
            {
                lights.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                alpha += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            while (alpha > 0)
            {
                lights.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
                alpha -= 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
        }
        isActive = false;
        lights.SetActive(false);
        spriteRenderer.sortingOrder = -4;
    }
}
