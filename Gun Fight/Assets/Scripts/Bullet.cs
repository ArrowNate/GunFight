using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletDamage;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        bulletDamage = 10;
        rb.AddRelativeForce(Vector2.right * bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerOne")
        {
            collision.gameObject.GetComponent<PlayerOne>().PlayerOneTakeDamage(bulletDamage);
        }

        if (collision.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "PlayerTwo")
        {
            collision.gameObject.GetComponent<PlayerTwo>().PlayerTwoTakeDamage(bulletDamage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
