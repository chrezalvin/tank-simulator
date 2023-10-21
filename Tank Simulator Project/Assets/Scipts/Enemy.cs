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

    public CheckEnemyList checkEnemyList;

    private GameObject lockPlayer = null;
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
            turret.transform.LookAt(lockPlayer.transform.position);
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
    }
}
