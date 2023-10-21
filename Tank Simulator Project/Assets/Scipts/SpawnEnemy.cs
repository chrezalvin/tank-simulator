using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    GameObject tankModel;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(tankModel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
