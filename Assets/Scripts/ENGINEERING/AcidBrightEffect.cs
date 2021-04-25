using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcidBrightEffect : MonoBehaviour {

	private float alpha;
	private Coroutine acidShine;
    // Start is called before the first frame update
    void Start() {
        acidShine = StartCoroutine(acidShineEffect());
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    private IEnumerator acidShineEffect() {
		while(true) {
			alpha = 0;
			while(alpha < 0.5f) {
				GetComponent<SpriteRenderer>().color = new Color(0,1,0,alpha);
				alpha += 0.1f;
				yield return new WaitForSeconds(0.1f);
			}
			while(alpha > 0) {
				GetComponent<SpriteRenderer>().color = new Color(0,1,0,alpha);
				alpha -= 0.1f;
				yield return new WaitForSeconds(0.1f);
			}
		}
    }
}

