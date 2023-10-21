using UnityEngine;

public class Aim : MonoBehaviour
{
    public Transform target; // The tank's Transform
    public Transform turret; // The tank's turret Transform
    public Transform muzzle; // The tank's muzzle Transform
    public float sphereRadius = 5f;
    public float verticalOffset = 2f; // Adjust this value to raise the camera
    public float sensitivity = 2f;
    public float turretRotationSpeed = 10f; // Adjust this value in the Unity Editor
    public float muzzleRotationSpeed = 5f; // Adjust this value in the Unity Editor
    public float muzzleVerticalLimit = 30f; // Adjust this value in the Unity Editor
    public Color rayColor = Color.red;

    private float mouseX = 0f;
    private float mouseY = 0f;
    private Quaternion defaultTurretRotation;
    private Quaternion defaultMuzzleRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Store the default rotations of the turret and muzzle for reference
        defaultTurretRotation = turret.rotation;
        defaultMuzzleRotation = muzzle.localRotation;
    }

    private void Update()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;
        mouseY = Mathf.Clamp(mouseY, -muzzleVerticalLimit, muzzleVerticalLimit); // Apply vertical limit

        // Calculate camera position on the outer circumference of the sphere with vertical offset
        float x = sphereRadius * Mathf.Sin(mouseX * Mathf.Deg2Rad) * Mathf.Cos(mouseY * Mathf.Deg2Rad);
        float y = sphereRadius * Mathf.Sin(mouseY * Mathf.Deg2Rad) + verticalOffset;
        float z = sphereRadius * Mathf.Cos(mouseX * Mathf.Deg2Rad) * Mathf.Cos(mouseY * Mathf.Deg2Rad);

        Vector3 position = new Vector3(x, y, z) + target.position;

        transform.position = position;

        // Adjust the camera's look direction to point slightly above the tank
        Vector3 lookDirection = (target.position + new Vector3(0, 1, 0) * verticalOffset) - transform.position;
        transform.rotation = Quaternion.LookRotation(lookDirection);

        // Perform a raycast from the camera position towards the aim direction
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 100f, rayColor);

        // Aiming the turret and muzzle with a realistic slow spin
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            Vector3 targetPoint = hit.point;
            Vector3 turretTargetDirection = new Vector3(targetPoint.x, turret.position.y, targetPoint.z) - turret.position;
            Quaternion turretTargetRotation = Quaternion.LookRotation(turretTargetDirection);
            turret.rotation = Quaternion.RotateTowards(turret.rotation, turretTargetRotation, turretRotationSpeed * Time.deltaTime);

            Vector3 relativeVector = targetPoint - muzzle.position;
            Vector3 targetEulerAngle = Quaternion.LookRotation(relativeVector).eulerAngles;
            float clampedAngle = Mathf.Clamp(targetEulerAngle.x, -muzzleVerticalLimit, muzzleVerticalLimit);
            Vector3 clampedEulerAngle = new Vector3(clampedAngle, 0, 0);
            Quaternion muzzleTargetRotation = Quaternion.Euler(clampedEulerAngle);
            muzzle.localRotation = Quaternion.RotateTowards(muzzle.localRotation, muzzleTargetRotation, muzzleRotationSpeed * Time.deltaTime);
        }
        else
        {
            // Reset to default rotation if no target is hit
            turret.rotation = Quaternion.RotateTowards(turret.rotation, defaultTurretRotation, turretRotationSpeed * Time.deltaTime);
            muzzle.localRotation = Quaternion.RotateTowards(muzzle.localRotation, defaultMuzzleRotation, muzzleRotationSpeed * Time.deltaTime);
        }
    }
}
