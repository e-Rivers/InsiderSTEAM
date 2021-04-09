using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargedBullet : MonoBehaviour
{
    // Public attributes
    public GameObject explosion;
    public float speed = 5.0f;

    // Private attributes
    private Rigidbody2D rb2d;
    private Vector3 expOffset;

    // Start is called before the first frame update
    void Start()
    {
        // Set components
        rb2d = GetComponent<Rigidbody2D>();
        // Set initial values
        expOffset = new Vector3(0f, -3.2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.position += Vector2.down * speed * Time.deltaTime;   
    }

    // Check if collides with bouncepads
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bouncepad"))
        {
            Destruction();
        }
    }

    // Check if collides with ground
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Destruction();
        }
    }

    // Animate destruction
    void Destruction()
    {
        GameObject expInst = Instantiate(explosion, transform.localPosition + expOffset, Quaternion.identity);
        expInst.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}
