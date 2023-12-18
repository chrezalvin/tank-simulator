using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 10f;
    public float deceleration = 3f;
    public float brakeDeceleration = 10f;
    public float rotationSpeed = 10f;

    private float currentSpeed = 0f;
    private bool isMovingForward = false;
    private bool isMovingBackward = false;
    private bool isTurningLeft = false;
    private bool isTurningRight = false;


    private void UpdateTankMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (currentSpeed <= 0)
            {
                isMovingBackward = false;
                isMovingForward = true;
            }
            else
            {
                isMovingBackward = false;
                isMovingForward = true;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (currentSpeed >= 0)
            {
                isMovingForward = false;
                isMovingBackward = true;
            }
            else
            {
                isMovingForward = false;
                isMovingBackward = true;
            }
        }
        else
        {
            isMovingForward = false;
            isMovingBackward = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            isTurningLeft = true;
            isTurningRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isTurningRight = true;
            isTurningLeft = false;
        }
        else
        {
            isTurningLeft = false;
            isTurningRight = false;
        }

        if (isMovingForward)
        {
            currentSpeed = Mathf.Min(currentSpeed + acceleration * Time.deltaTime, maxSpeed);
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        else if (isMovingBackward)
        {
            if (currentSpeed > 0)
            {
                currentSpeed = Mathf.Max(currentSpeed - brakeDeceleration * Time.deltaTime, 0);
            }
            else
            {
                currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, -maxSpeed / 2f);
            }
            transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        }
        else
        {
            if (currentSpeed > 0)
            {
                currentSpeed = Mathf.Max(currentSpeed - deceleration * Time.deltaTime, 0);
                transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            }
            else if (currentSpeed < 0)
            {
                currentSpeed = Mathf.Min(currentSpeed + deceleration * Time.deltaTime, 0);
                transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
            }
        }

        if (isTurningLeft)
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
        else if (isTurningRight)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }


    private void Update()
    {
        UpdateTankMovement();
    }

}
