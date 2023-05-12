using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOne : MonoBehaviour
{
    public Transform bulletSpawnPointOne;
    public float bulletOneAmount;
    public GameObject bullet;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        bulletOneAmount = 6;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            bulletOneAmount -= 1;
            Instantiate(bullet, bulletSpawnPointOne.position, Quaternion.identity);
        }

        if (bulletOneAmount > 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }
}
