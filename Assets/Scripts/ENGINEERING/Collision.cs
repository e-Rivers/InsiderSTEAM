using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    public GameObject DestroyedC;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool crash = false;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject player;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip crashClip;
    void Start()
    {
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnGUI()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (crash)
        {
            DestroyedC.GetComponent<DestroyedCoins>().DestroyedC = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("KillerPlatform"))
        {
            StartCoroutine("WaitForLoad");
        }
    }

    IEnumerator WaitForLoad()
    {
        audioSource.PlayOneShot(crashClip);
        MoveCharacter.instance.disableInput = true;
        Instantiate(explosion, transform.position, Quaternion.identity);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(1f);
        crash = true;
    }
}
