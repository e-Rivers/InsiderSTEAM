using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Adjustable variables
    public GameObject explosion;
    public GameObject damageExplosion;
    public int hp;
    public int score = 150;
    public bool isDead = false;
    // Non-adjustable variables
    private float vulnerableTime = 0.1f;
    private float vulnerableTimer = 0.1f;
    private bool isInvulnerable = false;
    private EnemySound soundPlayer;

    // Start is called before first frame update
    private void Start()
    {
        soundPlayer = GetComponent<EnemySound>();
    }

    // Update is called once per frame
    void Update()
    {
        // If hp reaches 0 or less and enemy is still alive
        if (hp <= 0 && !isDead)
        {
            Kill(true);
        }
        // If enemy invulnerability timer is over
        if (vulnerableTimer < vulnerableTime)
        {
            // Let enemy receive damage again
            isInvulnerable = true;
            vulnerableTimer += Time.deltaTime;
        } else
        {
            // Make enemy temporarily invulnerable
            isInvulnerable = false;
        }
    }

    // Do every time a player's bullet touches enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If enemy collides with a player bullet
        if (collision.CompareTag("PlayerBullet") && !isDead)
        {
            // If enemy can receive damage
            if (!isInvulnerable)
            {
                // Damage enemy
                hp--;
                // Reset timer
                isInvulnerable = true;
                vulnerableTimer = 0.0f;
                // Animate bullet touching enemy
                var explosionInstance = Instantiate(damageExplosion, collision.transform.localPosition, transform.localRotation);
                explosionInstance.transform.parent = transform;
                // Play damage sound
                soundPlayer.PlayDamage();
            }
        }
        // If enemy collides with big platform projectile
        if (collision.CompareTag("KillerPlatform") && !isDead)
        {
            Kill(true);
        }
        // If enemy is on scene while player has to answer a Math Problem
        if (collision.CompareTag("ForcefulKiller"))
        {
            Kill();
        }
    }

    // Instantiate EnemyExplosion and destroy current gameObject
    public void Kill(bool countToPlayer=false)
    {
        // Check if death trigger is disabled to avoid accidental shooting after death
        if (!isDead)
        {
            // Create explosion animation object
            var explosionInstance = Instantiate(explosion, transform.position, transform.localRotation);
            explosionInstance.transform.parent = transform.parent;
            isDead = true;
            // Assign points for killing enemy
            if (countToPlayer)
            {
                if (ScoreSystem.instance.canScore)
                {
                    ScoreText.scoreValue += score;
                }
                KillsText.kills++;
            }
            // Destroy object
            Destroy(gameObject);
            // Play sound
            soundPlayer.PlayDeath();
        }
    }
}
