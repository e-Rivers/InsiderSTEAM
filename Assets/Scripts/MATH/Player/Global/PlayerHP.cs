using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    // Public self reference
    public static PlayerHP instance;
    // Public attributes
    public int lives = 5;
    public int maxLives = 10;
    public int grabbedHealingTiles = 0;
    public HealthSystem hs;
    public GameObject explosion;
    // Private components
    private CameraShake camShake;
    private FireballMovement fireball;
    private float damageTimer = 0.0f;
    private bool canGetDamaged = true;

    // Start is called before the game starts
    void Start()
    {
        // Self reference assignment
        instance = this;
        // Health system assignment
        hs.DrawHearts(lives, maxLives);
        // Camera assignment
        camShake = Camera.main.GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Check if player is dead
        if (lives <= 0)
        {
            Kill();
        }
        // Prevents instant double damage
        if (damageTimer <= 0.0f)
        {
            canGetDamaged = true;
        } else
        {
            damageTimer -= Time.fixedDeltaTime;
        }
        // Checks if player has grabbed a multiple of 3 healing tiles
        if (grabbedHealingTiles == 3)
        {
            Heal(2);
            grabbedHealingTiles = 0;
        }
    }

    // Check enemy collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            camShake.ShakeCamera();
            if (canGetDamaged)
            {
                damageTimer = 0.7f;
                canGetDamaged = false;
                Damage(1);
            }
        }
    }

    // Check projectiles touching
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if it's an enemy projectile
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Get fireball fireballMovement identifier
            fireball = collision.gameObject.GetComponent<FireballMovement>();
            // If it's a tiny projectile
            if (fireball.identifier == 1)
            {
                if (canGetDamaged)
                {
                    camShake.ShakeCamera(0.2f, 0.2f);
                    Damage(1);
                    canGetDamaged = false;
                }
            }
            if (fireball.identifier == 2)
            {
                if (canGetDamaged)
                {
                    camShake.ShakeCamera(0.4f, 0.3f);
                    Damage(2);
                    canGetDamaged = false;
                }
            }
            // Destroy projectile
            fireball.Destruction(true);
            // Reset damage timer
            damageTimer = 0.7f;
        }
        if (collision.CompareTag("Ground") || collision.CompareTag("Wall"))
        {
            lives = 0;
            Kill();
        }
        if (collision.CompareTag("CeilingKiller"))
        {
            if (!MathPlayerMovement.instance.disableXInput)
            {
                lives = 0;
                Kill();
            }
        }
    }

    // Damage player
    public void Damage(int damage)
    {
        if (lives - damage < 0)
        {
            damage = lives;
        }
        lives -= damage;
        hs.DrawHearts(lives, maxLives);
        PlayerSounds.instance.PlayDamage();
    }
    
    // Heal player
    public void Heal(int hp)
    {
        if (lives + hp > maxLives)
        {
            hp = maxLives - lives;
        }
        lives += hp;
        hs.DrawHearts(lives, maxLives);
    }

    // Kill player
    public void Kill()
    {
        GameObject explosionInstance = Instantiate(explosion, transform.position, Quaternion.identity);
        PlayerSounds.instance.PlayDeath();
        // Announce that the game is over
        AnnouncerVoice.instance.audioSource.clip = AnnouncerVoice.instance.voices[1];
        AnnouncerVoice.instance.audioSource.PlayDelayed(0.5f);
        Destroy(gameObject);
    }

}
