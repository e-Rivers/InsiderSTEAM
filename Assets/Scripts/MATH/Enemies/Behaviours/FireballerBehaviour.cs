using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballerBehaviour : MonoBehaviour
{
    public float xSpeed = 5f;
    public float ySpeed = 2f;
    public int shootCount = 0;
    public int shootTrigger = 3;
    public bool canShoot = false;
    public GameObject fireball;

    private Rigidbody2D rb2d;
    private EnemyDeath behaviour;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize components
        rb2d = GetComponent<Rigidbody2D>();
        behaviour = GetComponent<EnemyDeath>();
        // Initialize up and down movement
        _ = StartCoroutine(nameof(SwitchVerticalMovement));
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
