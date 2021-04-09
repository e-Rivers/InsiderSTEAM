using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    // Variables that can be altered manually
    public GameObject fireball;
    public float speed = 10;
    public float bouncingForce = 25.0f;
    public int identifier = 0;
    public int timesGrabbed = 0;
    public bool isGrabbed = false;
    public bool jumpedOnce = false;
    // Tile components
    private Rigidbody2D rb2d;

    private void Start()
    {
        // Set component values
        rb2d = GetComponent<Rigidbody2D>();
        // Set initial values
        timesGrabbed = 0;
        isGrabbed = false;
        jumpedOnce = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(speed, 0f, 0f);
        if (this.gameObject.tag == "Bouncepad") {
            transform.position += movement * Time.deltaTime;
        } else if (this.gameObject.tag == "Ceiling") {
            transform.position -= movement * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            if (identifier == 3)
            {
                rb2d.constraints = RigidbodyConstraints2D.None;
                rb2d.velocity = new Vector2(0, -10.0f);
            }
        }
    }

    public void Shoot()
    {
        GameObject fbInstance = Instantiate(fireball, transform.localPosition, fireball.transform.localRotation);
        fbInstance.transform.parent = transform.parent;
    }

}
