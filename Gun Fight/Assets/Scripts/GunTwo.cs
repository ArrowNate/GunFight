using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTwo : MonoBehaviour
{
    public Transform bulletSpawnPointTwo;
    public float bulletTwoAmount;
    public GameObject bullet;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        bulletTwoAmount = 6;
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            bulletTwoAmount -= 1;
            Instantiate(bullet, bulletSpawnPointTwo.position, Quaternion.identity);
        }

        if (bulletTwoAmount > 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }
    }
}
