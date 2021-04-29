using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSwap : MonoBehaviour
{
    // Private attributes
    [SerializeField] Image[] characters;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Swap");
    }

    // Swap between characters
    IEnumerator Swap()
    {
        while (true)
        {
            int index = Random.Range(0, characters.Length);
            // Enable current character
            characters[index].enabled = true;
            // Increase opacity
            while (characters[index].color.a < 1f)
            {
                characters[index].color += new Color(0f, 0f, 0f, 0.01f);
                yield return null;
            }
            // Hold image for some time
            characters[index].color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(1f);
            // Decrease opacity
            while (characters[index].color.a > 0.01f)
            {
                characters[index].color -= new Color(0f, 0f, 0f, 0.01f);
                yield return null;
            }
            // Hold blank image for some time
            characters[index].color = new Color(1f, 1f, 1f, 0f);
            // Swap character
            yield return null;
        }
    }
}
