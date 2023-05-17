using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public float playerOneHealth;
    public float playerOneSpeed;
    private bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        playerOneHealth = 10;
    }

    public void PlayerOneTakeDamage(float bulletDamage)
    {
        if (playerOneHealth <= 10)
        {
            playerOneHealth -= bulletDamage;
        }

        if (playerOneHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Stopper"))
        {
            canMove = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stopper"))
        {
            canMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector2.right * playerOneSpeed * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * playerOneSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * playerOneSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * playerOneSpeed * Time.deltaTime);
        }
        /*float verticalInput = Input.GetAxisRaw("Vertical");  // Get vertical input from player
        transform.Translate(new Vector3(0, verticalInput, 0) * playerOneSpeed * Time.deltaTime);  // Move player up or down based on input*/

        /*        if (Input.GetKeyDown(KeyCode.W))
        */
    }
}
