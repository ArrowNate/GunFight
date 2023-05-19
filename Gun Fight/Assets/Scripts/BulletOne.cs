using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletOne : MonoBehaviour
{
    public float bulletOneSpeed;
    public float bulletOneDamage;
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletOneSpeed = 600.0f;
        bulletOneDamage = 10;
        rb.AddRelativeForce(Vector2.right * bulletOneSpeed);
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

        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }
}