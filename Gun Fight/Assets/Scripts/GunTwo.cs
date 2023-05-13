using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTwo : MonoBehaviour
{
    public Transform bulletSpawnPointTwo;
    public float bulletTwoAmount;
    public GameObject bullet;
    private bool canShoot;

    public GameObject objectToRotateTwo;
    public float rotationSpeedTwo = 500.0f;
    public float targetAngleUpTwo = 20.0f;
    public float targetAngleStraightTwo = 0.0f;
    public float targetAngleDownTwo = -20.0f;

    private bool isRotatingUp = false;
    private bool isRotatingStraight = false;
    private bool isRotatingDown = false;

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

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            isRotatingUp = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            isRotatingStraight = true;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isRotatingDown = true;
        }

        if (isRotatingUp)
        {
            float currentAngle = objectToRotateTwo.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleUpTwo, rotationSpeedTwo * Time.fixedDeltaTime);
            objectToRotateTwo.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleUpTwo))
            {
                isRotatingUp = false;
            }
        }

        if (isRotatingStraight)
        {
            float currentAngle = objectToRotateTwo.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleStraightTwo, rotationSpeedTwo * Time.fixedDeltaTime);
            objectToRotateTwo.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleStraightTwo))
            {
                isRotatingStraight = false;
            }
        }

        if (isRotatingDown)
        {
            float currentAngle = objectToRotateTwo.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleDownTwo, rotationSpeedTwo * Time.fixedDeltaTime);
            objectToRotateTwo.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleDownTwo))
            {
                isRotatingDown = false;
            }
        }
    }
}
