using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOne : MonoBehaviour
{
    public float bulletOneSpeed;
    public float bulletOneDamage;
    private Rigidbody2D rb;
    public Rigidbody2D rb2;
    public LayerMask bounceLayers;
    public int maxBounces = 3;

    private int bounces = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletOneSpeed = 600.0f;
        bulletOneDamage = 10;
        rb.AddRelativeForce(Vector2.right * bulletOneSpeed);
        rb2.velocity = transform.right * bulletOneSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            collision.gameObject.GetComponent<PlayerTwo>().PlayerTwoTakeDamage(bulletOneDamage);
        }

        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Cactus")
        {
            collision.gameObject.GetComponent<Cactus>().CactusTakeDamage(bulletOneDamage);
        }

        if (bounceLayers == (bounceLayers | (1 << collision.gameObject.layer)))
        {
            bounces++;

            if (bounces >= maxBounces)
            {
                Destroy(gameObject);
            }
            else
            {
                // Reflect the velocity of the bullet off the collision normal
                Vector2 reflect = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
                rb.velocity = reflect.normalized * bulletOneSpeed;
            }
        }
        else
        {
            // Hit an object that the bullet can't bounce off of, destroy the bullet
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
