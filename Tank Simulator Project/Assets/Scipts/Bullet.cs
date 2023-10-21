using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Adjust this value to control the bullet speed
    public float lifeDuration = 3f; // Adjust this value to control how long the bullet exists

    private float lifeTimer;

    private void Start()
    {
        lifeTimer = lifeDuration;
    }

    private void Update()
    {
        // Move the bullet forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Reduce the life timer
        lifeTimer -= Time.deltaTime;

        // Destroy the bullet if the life timer runs out
        if (lifeTimer <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet when it collides with an object
        Destroy(gameObject);
    }
}
