using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTwo : MonoBehaviour
{
    public float bulletTwoSpeed;
    public float bulletTwoDamage;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletTwoSpeed = 600.0f;
        bulletTwoDamage = 10;
        rb.AddRelativeForce(Vector2.left * bulletTwoSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerOne")
        {
            collision.gameObject.GetComponent<PlayerOne>().PlayerOneTakeDamage(bulletTwoDamage);
        }

        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Cactus")
        {
            collision.gameObject.GetComponent<Cactus>().CactusTakeDamage(bulletTwoDamage);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
