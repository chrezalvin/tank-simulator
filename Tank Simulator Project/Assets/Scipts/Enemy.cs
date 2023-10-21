using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public float turretRotateSpeed = 20;
    public float moveSpeed = 20;
    public float fireDelay = 3;

    public HealthBar healthBar;
    public GameObject player;

    public GameObject turret;
    public Player playerScript;

    public GameObject explosionEffect = null;

    public GameObject bulletModel;
    public ParticleSystem bulletEffect;
    public float bulletVelocity = 20;
    public float shootColdown = 2;
    public Transform firePoint;

    public CheckEnemyList checkEnemyList;

    private GameObject lockPlayer = null;
    private float currentColdown = 0;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(lockPlayer != null)
        {
            Vector3 tankToPlayer = lockPlayer.transform.position - turret.transform.position;
            Quaternion toRotation = Quaternion.LookRotation(new Vector3(tankToPlayer.x, 0, tankToPlayer.z));
            turret.transform.rotation = Quaternion.Lerp(turret.transform.rotation, toRotation, turretRotateSpeed * Mathf.PI * Time.deltaTime / 180);

            // if close enough, start shooting
            if (Mathf.Abs(Quaternion.Dot(turret.transform.rotation, toRotation)) > 0.9f && currentColdown < 0)
            {
                Shoot();
                currentColdown = shootColdown;
            }
        }

        currentColdown -= Time.deltaTime;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth < damage)
        {
            if (explosionEffect)
            {
                var explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                Destroy(explosion, 3);
            }

            checkEnemyList.ReportEnemyDestroyed();
            Destroy(this.gameObject);
        }

        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == player.tag)
        {
            lockPlayer = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            lockPlayer = null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == player.tag)
        {
            playerScript.TakeDamage(5);
            TakeDamage(10);
        }

        if(collision.gameObject.tag == "bullet")
        {
            TakeDamage(20);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletModel, firePoint.position, firePoint.rotation);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = firePoint.forward * bulletVelocity;
        }
        bulletEffect.Play(); // Trigger the particle effect
    }
}
