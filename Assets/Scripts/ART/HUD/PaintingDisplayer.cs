using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintingDisplayer : MonoBehaviour
{
    // Public attributes
    public GameObject explosion;
    // Private attributes
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (InstructionManager.instance.win) {
            image.enabled = true;
            image.sprite = InstructionManager.instance.currPainting;
            GameObject expInst = Instantiate(explosion, transform.localPosition, Quaternion.identity);
            expInst.transform.parent = transform.parent;
        }
    }
}
