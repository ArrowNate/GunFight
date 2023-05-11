using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public float playerOneHealth;
    public float playerOneSpeed;

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

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");  // Get vertical input from player
        transform.Translate(new Vector3(0, verticalInput, 0) * playerOneSpeed * Time.deltaTime);  // Move player up or down based on input

        /*        if (Input.GetKeyDown(KeyCode.W))
        */
    }
}
