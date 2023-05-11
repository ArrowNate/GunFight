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
        
    }
}
