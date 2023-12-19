using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

// must have audiosource component
[RequireComponent(typeof(AudioSource))]
public class Dynamusic : MonoBehaviour
{
    public Transform playerPos;
    public GameObject enemyList;

    public float minVolume = 0.2f;
    public float maxVolume = 1f;
    public int maxEnemies = 5;
    public int minEnemies = 2;
    public float radius = 10f;

    private int amountEnemyNearby = 0;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // get amount of enemies nearby
        int count = 0;
        foreach(Transform child in enemyList.transform)
        {
            float distance = Vector3.Distance(child.position, playerPos.position);
            if (distance < radius)
                ++count;
        }
        amountEnemyNearby = count;

        // set volume based on how many enemies are there
        float volume = Mathf.Lerp(minVolume, maxVolume, (float)Mathf.Clamp(amountEnemyNearby, 0, maxEnemies) / maxEnemies);

        audioSource.volume = volume;

        // set position to player position
        transform.position = playerPos.position;
    }
}
