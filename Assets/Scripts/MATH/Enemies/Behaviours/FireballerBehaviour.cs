using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballerBehaviour : MonoBehaviour
{
    public float xSpeed = 5f;
    public float ySpeed = 2f;
    public int shootCount = 0;
    public int shootTrigger = 3;
    public string enemyType;
    public bool canShoot = false;
    public GameObject fireball;
    public AudioClip[] enemySounds;
    public AudioClip shootSound;

    private Rigidbody2D rb2d;
    private EnemyDeath behaviour;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        // Initialize components
        rb2d = GetComponent<Rigidbody2D>();
        behaviour = GetComponent<EnemyDeath>();
        // Initialize up and down movement
        _ = StartCoroutine(nameof(SwitchVerticalMovement));
        // Play sound
        switch (enemyType)
        {
            case "small":
                audioSource = GameObject.Find("SmallEnemySoundSource").GetComponent<AudioSource>();
                if (EnemyControl.instance.smallEnemies == 0)
                {
                    audioSource.clip = enemySounds[Random.Range(0, enemySounds.Length)];
                    audioSource.Play();
                }
                EnemyControl.instance.smallEnemies++;
                break;
            case "big":
                audioSource = GameObject.Find("BigEnemySoundSource").GetComponent<AudioSource>();
                if (EnemyControl.instance.bigEnemies == 0)
                {
                    audioSource.clip = enemySounds[Random.Range(0, enemySounds.Length)];
                    audioSource.Play();
                }
                EnemyControl.instance.bigEnemies++;
                break;
        }
    }

    // Check enemy status
    private void FixedUpdate()
    {
        if (behaviour.isDead)
        {
            canShoot = false;
        }
    }

    // Shoot at frame 44 from animator
    public void Shoot()
    {
        if (shootCount % shootTrigger == 0 && canShoot)
        {
            var projectile = Instantiate(fireball, transform.position, fireball.transform.localRotation);
            projectile.transform.parent = transform.parent;
            if (EnemyControl.instance.canTriggerSounds)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
        shootCount++;
    }

    // Check if GameObject is in or out of the screen
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.name == "CeilingSpawner")
        {
            canShoot = true;
        }

        if (coll.gameObject.name == "CeilingDestroyer")
        {
            switch (enemyType)
            {
                case "small":
                    EnemyControl.instance.smallEnemies--;
                    break;
                case "big":
                    EnemyControl.instance.bigEnemies--;
                    break;
            }
            audioSource.Stop();
            Destroy(this.gameObject);
        }
    }


    // Shift vertical dircetion until character is destroyed
    IEnumerator SwitchVerticalMovement()
    {
        while (true)
        {
            rb2d.velocity = new Vector3(-xSpeed, ySpeed, 0);
            yield return new WaitForSeconds(1f);
            ySpeed *= -1;
        }
    }
}
