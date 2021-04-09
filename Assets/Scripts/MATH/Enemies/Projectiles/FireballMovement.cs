using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    // Public attributes
    public GameObject destroyedExplosion;
    public GameObject onContactExplosion;
    public float speed = 20f;
    public float direction = 1.0f;
    public int identifier = 1;
    // Private attributes
    private Rigidbody2D rb2d;

    // Initialize variables
    void Start()
    {
        // Get components
        rb2d = GetComponent<Rigidbody2D>();
        // Assign initial values to components
        rb2d.velocity = new Vector3(speed * direction, 0, 0);
    }

    // Check for collisions with any trigger
    private void OnTriggerEnter2D(Collider2D coll)
    {
        // If projectile reaches side limits
        if (coll.gameObject.name == "CeilingDestroyer" || coll.gameObject.name == "CeilingSpawner")
        {
            Destruction();
        }
        // If bullet touches a player bullet or a big platform projectile
        if (coll.CompareTag("PlayerBullet") || coll.CompareTag("KillerPlatform")) {
            // Check if player can score
            if (ScoreSystem.instance.canScore)
            {
                ScoreText.scoreValue += 50;
            }
            // Create explosion animation
            GameObject explosion = Instantiate(destroyedExplosion, transform.position, Quaternion.identity);
            explosion.transform.parent = transform.parent;
            // Destroy gameObject
            Destruction();
        }
        // If bullet is on scene while player has to answer a Math Problem
        if (coll.CompareTag("ForcefulKiller"))
        {
            GameObject explosion = Instantiate(destroyedExplosion, transform.position, Quaternion.identity);
            explosion.transform.parent = transform.parent;
            Destruction();
        }
    }

    // Destroy current GameObject
    public void Destruction(bool explode = false)
    {
        // If projectile has to create only a contact explosion
        if (explode)
        {
            GameObject explosion = Instantiate(onContactExplosion, transform.position, Quaternion.identity);
            explosion.transform.parent = transform.parent;
        }
        Destroy(gameObject);
    }
}
