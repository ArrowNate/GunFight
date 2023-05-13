using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : MonoBehaviour
{
    public float cactusHealth;

    // Start is called before the first frame update
    void Start()
    {
        cactusHealth = 30;
    }

    public void CactusTakeDamage(float bulletDamage)
    {
        if (cactusHealth <= 30)
        {
            cactusHealth -= bulletDamage;
        }

        if (cactusHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
