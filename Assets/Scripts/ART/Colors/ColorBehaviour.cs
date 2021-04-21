using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    // Public attributes
    public string identifier;

    // Private attributes
    private Animator anim;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] fallClips;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GameObject.Find("MainSoundSource").GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Detect collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            anim.SetTrigger("Fell");
            audioSource.PlayOneShot(fallClips[Random.Range(0, fallClips.Length)]);
        }
    }

    // Destroy gameObject
    public void Disappear()
    {
        Destroy(gameObject);
    }
}
