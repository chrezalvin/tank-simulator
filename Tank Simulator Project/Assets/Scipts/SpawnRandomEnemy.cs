using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandomEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject[] tankModels;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tankModels[Random.Range(0, tankModels.Length)]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
