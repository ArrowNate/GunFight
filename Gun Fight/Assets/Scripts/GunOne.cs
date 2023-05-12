using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunOne : MonoBehaviour
{
    public Transform bulletSpawnPointOne;
    public float bulletOneAmount;
    public GameObject bullet;
    private bool canShoot;

    public GameObject objectToRotate;
    //public KeyCode rotateButton = KeyCode.Q;
    public float rotationSpeed = 500.0f;
    public float targetAngleUp = 20.0f;
    public float targetAngleStraight = 0.0f;
    public float targetAngleDown = -20.0f;

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
            float currentAngle = objectToRotate.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleUp, rotationSpeed * Time.fixedDeltaTime);
            objectToRotate.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleUp))
            {
                isRotatingUp = false;
            }
        }

        if (isRotatingStraight)
        {
            float currentAngle = objectToRotate.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleStraight, rotationSpeed * Time.fixedDeltaTime);
            objectToRotate.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleStraight))
            {
                isRotatingStraight = false;
            }
        }

        if (isRotatingDown)
        {
            float currentAngle = objectToRotate.transform.eulerAngles.z;
            float newAngle = Mathf.MoveTowardsAngle(currentAngle, targetAngleDown, rotationSpeed * Time.fixedDeltaTime);
            objectToRotate.transform.eulerAngles = new Vector3(0.0f, 0.0f, newAngle);

            if (Mathf.Approximately(newAngle, targetAngleDown))
            {
                isRotatingDown = false;
            }
        }

        /*        // Get the current angle of the object
                float currentAngle = transform.rotation.eulerAngles.z;

                // Calculate the difference between the current angle and the target angle
                float angleDifference = targetAngle - currentAngle;

                // Rotate the object towards the target angle
                transform.Rotate(new Vector3(0, 0, angleDifference) * Time.deltaTime);*/


    }

/*    void FixedUpdate()
    {
        
    }*/
}
