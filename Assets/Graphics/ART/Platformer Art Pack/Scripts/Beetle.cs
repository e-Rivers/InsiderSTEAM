using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beetle : MonoBehaviour
{
    public float xVelocity = 3f;
    Rigidbody2D beetleRb;
    SpriteRenderer spriteRend;
    public float castDist = 0.2f;
    Vector2 castDir;

    void Start()
    {
        beetleRb = GetComponent<Rigidbody2D>();
        spriteRend = GetComponent<SpriteRenderer>();
        beetleRb.velocity = new Vector2 (xVelocity, 0);
        castDir = Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, castDir, castDist);
        if (hit.collider != null && (hit.collider.tag != ("Player")))
        {
            spriteRend.transform.localScale = new Vector3(-spriteRend.transform.localScale.x, 1, 1);
            beetleRb.velocity *= -1;
            castDir.x *= -1;
        }
    }
}
