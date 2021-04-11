using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StdShooterBehaviour : MonoBehaviour
{
    // Initial declaration of variables
    public float xSpeed = -20f;
    public float ySpeed = 0f;
    public bool canShoot = false;
    public Transform gunPoint;
    public GameObject rightFire;
    public GameObject leftFire;
    public AudioClip[] enemySounds;
    public AudioClip shootSound;

    // Private components
    private EnemyDeath behaviour;
    private Rigidbody2D rb2d;
    private float currXSpeed;
    private float currYSpeed;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Awake()
    {
        // Variable assignment
        currXSpeed = xSpeed;
        currYSpeed = ySpeed;
        // Get components
        rb2d = GetComponent<Rigidbody2D>();
        behaviour = GetComponent<EnemyDeath>();
        audioSource = GameObject.Find("MediumEnemySoundSource").GetComponent<AudioSource>();
        // Assign initial velocity
        rb2d.velocity = new Vector2(currXSpeed, currYSpeed);
        // Play sound
        if (EnemyControl.instance.mediumEnemies == 0)
        {
            audioSource.clip = enemySounds[Random.Range(0, enemySounds.Length)];
            audioSource.Play();
        }
        EnemyControl.instance.mediumEnemies++;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(currXSpeed, currYSpeed);
        // Check enemy status
        if (behaviour.isDead)
        {
            canShoot = false;
        }
    }

    // Allow shooting
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "CeilingSpawner")
        {
            canShoot = true;
        }

        if (collision.name == "CeilingDestroyer")
        {
            EnemyControl.instance.mediumEnemies--;
            audioSource.Stop();
            Destroy(this.gameObject);
        }
    }

    // Upwards movement
    public void MoveUp()
    {
        ResetMovement();
        currYSpeed += ySpeed;
    }

    // Downwards movement
    public void MoveDown()
    {
        ResetMovement();
        currYSpeed -= ySpeed;
    }

    // Horizontal movement
    public void MoveLeft()
    {
        ResetMovement();
        currXSpeed -= xSpeed;
    }

    // Set current speed to 0
    public void ResetMovement()
    {
        currXSpeed *= 0;
        currYSpeed *= 0;
    }

    // Shoot projectile from gunpoint
    public void Shoot()
    {
        if (canShoot)
        {
            var leftProjectile = Instantiate(rightFire, gunPoint.position, rightFire.transform.localRotation);
            var rightProjectile = Instantiate(leftFire, gunPoint.position, leftFire.transform.localRotation);
            leftProjectile.transform.parent = transform.parent;
            rightProjectile.transform.parent = transform.parent;
            if (EnemyControl.instance.canTriggerSounds)
            {
                audioSource.PlayOneShot(shootSound);
            }
        }
    }
}
