using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathAnimation : MonoBehaviour
{
    // Private attributes
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Trigger after explosion
    public void CallAfterAnimation()
    {
        anim.SetTrigger("HasExploded");
    }
}
