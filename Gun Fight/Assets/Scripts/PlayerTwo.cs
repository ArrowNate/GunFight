using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour
{
    public float playerTwoHealth;
    public float playerTwoSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerTwoHealth = 10;
    }

    public void PlayerTwoTakeDamage(float bulletDamage)
    {
        if (playerTwoHealth <= 10)
        {
            playerTwoHealth -= bulletDamage;
        }

        if (playerTwoHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * playerTwoSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * playerTwoSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * playerTwoSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * playerTwoSpeed * Time.deltaTime);
        }
    }
}
