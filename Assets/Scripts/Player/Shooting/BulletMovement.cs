using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Destruction animation
    public GameObject explosion;
    public float speed = 25.0f;
    public bool hasPower = true;

    // Movement
    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    // Check if bullet is out of the screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("GroundDestroyer") || collision.CompareTag("CeilingDestroyer") || collision.gameObject.CompareTag("Ceiling") || collision.CompareTag("Bouncepad") || collision.CompareTag("AnswerTile"))
        {
            var expInstance = Instantiate(explosion, transform.position, Quaternion.identity);
            expInstance.transform.parent = transform.parent;
            Destroy(gameObject);
        }
    }
}
