using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShiningStars : MonoBehaviour
{

	public Image star1, star2, star3;
	private Coroutine shine1, shine2, shine3;
	
    // Start is called before the first frame update
    void Start()
    {
		shine1 = StartCoroutine(makeShine(star1));
		shine2 = StartCoroutine(makeShine(star2));
		shine3 = StartCoroutine(makeShine(star3));
    }

	private IEnumerator makeShine(Image star) {
		while(true) {
			star.canvasRenderer.SetAlpha(0);
			star.CrossFadeAlpha(1,0.5f,false);
			yield return new WaitForSeconds(0.5f);
			star.canvasRenderer.SetAlpha(1);
			star.CrossFadeAlpha(0,0.5f,false);
			yield return new WaitForSeconds(Random.Range(0.5f,1.5f));
		}
	}
}
