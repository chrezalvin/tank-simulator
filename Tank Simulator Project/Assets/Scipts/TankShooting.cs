using UnityEngine;

public class TankShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float shootingCooldown = 1f; // Adjust this value for the cooldown period
    [SerializeField] ParticleSystem muzzleBlast = null;
    private float currentCooldown = 0f;

    void Update()
    {
        if (currentCooldown <= 0f)
        {
            if (Input.GetMouseButtonDown(0)) // Check for left mouse button click
            {
                Shoot();
                currentCooldown = shootingCooldown; 
            }
        }
        else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = firePoint.forward * bulletSpeed;
        }
            muzzleBlast.Play(); // Trigger the particle effect
    }
}
