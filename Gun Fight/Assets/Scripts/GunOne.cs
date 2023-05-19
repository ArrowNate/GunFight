using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOne : MonoBehaviour
{
    public Transform bulletSpawnPointOne;
    public float bulletOneAmount;
    public GameObject bullet;
    private bool canShoot;

    public GameObject objectToRotateOne;
    public float rotationSpeedOne = 500.0f;
    public float targetAngleUpOne = 20.0f;
    public float targetAngleStraightOne = 0.0f;
    public float targetAngleDownOne = -20.0f;

    private bool isRotatingUp = false;
    private bool isRotatingStraight = false;
    private bool isRotatingDown = false;

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
            Instantiate(bullet, bulletSpawnPointOne.position, bulletSpawnPointOne.rotation);
        }

        if (bulletOneAmount > 0)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isRotatingUp = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isRotatingStraight = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isRotatingDown = true;
        }

        if (isRotatingUp)
        {
            float currentAngle = objectToRotateOne.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleUpOne, rotationSpeedOne * Time.fixedDeltaTime);
            objectToRotateOne.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleUpOne))
            {
                isRotatingUp = false;
            }
        }

        if (isRotatingStraight)
        {
            float currentAngle = objectToRotateOne.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleStraightOne, rotationSpeedOne * Time.fixedDeltaTime);
            objectToRotateOne.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleStraightOne))
            {
                isRotatingStraight = false;
            }
        }

        if (isRotatingDown)
        {
            float currentAngle = objectToRotateOne.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleDownOne, rotationSpeedOne * Time.fixedDeltaTime);
            objectToRotateOne.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleDownOne))
            {
                isRotatingDown = false;
            }
        }
    }
}