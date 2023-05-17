using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOne : MonoBehaviour
{
    public float bulletOneSpeed;
    public float bulletOneDamage;
    private Rigidbody2D rb;
    public LayerMask bounceLayers;
    public int maxBounces = 3;
    public float maxBounceAngle = 45f;

    private int bounces = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletOneSpeed = 600.0f;
        bulletOneDamage = 10;
        rb.AddRelativeForce(Vector2.right * bulletOneSpeed);
/*        rb.velocity = transform.right * bulletOneSpeed;
*/    }

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

        // Check if the bullet collided with a wall
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Calculate the new direction based on the wall's normal
            Vector2 wallNormal = collision.contacts[0].normal;
            Vector2 reflectedDirection = Vector2.Reflect(rb.velocity.normalized, wallNormal);

            // Limit the bounce angle to prevent steep bounces
            float angle = Vector2.Angle(reflectedDirection, rb.velocity);
            if (angle > maxBounceAngle)
            {
                float rotateAngle = Mathf.Atan2(reflectedDirection.y, reflectedDirection.x) * Mathf.Rad2Deg;
                rotateAngle = Mathf.MoveTowardsAngle(rotateAngle, Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg, maxBounceAngle);
                reflectedDirection = Quaternion.Euler(0, 0, rotateAngle) * rb.velocity.normalized;
            }

            // Update the bullet's velocity with the reflected direction
            rb.velocity = reflectedDirection * bulletOneSpeed;
        }

        /*if (bounceLayers == (bounceLayers | (1 << collision.gameObject.layer)))
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
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
