using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideExplode : MonoBehaviour
{
    public int damage = 10;
    public GameObject explosionEffect;
    public Player player;
    // public AudioSource playSound = null;

    void Start()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == player.tag || collision.gameObject.tag == "bullet")
        {
            player.TakeDamage(damage);

            Destroy(Instantiate(explosionEffect, transform.position, Quaternion.identity), 3);
            Destroy(this.gameObject);
        }
        
    }
}
