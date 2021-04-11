using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Public attributes
    public GameObject explosion;
    public float speed = 25.0f;
    public bool hasPower = true;

    // Private attributes
    private BulletSound sound;

    // Start is called before first frame update
    private void Start()
    {
        sound = GetComponent<BulletSound>();
    }

    // Movement
    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    // Check if bullet is out of the screen
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Projectile"))
        {
            sound.PlayDisappearSound();
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("GroundDestroyer") || collision.CompareTag("CeilingDestroyer") || collision.gameObject.CompareTag("Ceiling") || collision.CompareTag("Bouncepad") || collision.CompareTag("AnswerTile"))
        {
            var expInstance = Instantiate(explosion, transform.position, Quaternion.identity);
            expInstance.transform.parent = transform.parent;
            sound.PlayDisappearSound();
            Destroy(gameObject);
        }
    }
}
