using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    GameObject tankTower;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h_key = Input.GetAxis("Horizontal");
        float v_key = Input.GetAxis("Vertical");

        bool rot_left = Input.GetKey(KeyCode.Q);
        bool rot_right = Input.GetKey(KeyCode.E);

        tankTower.transform.Rotate(Vector3.up, h_key * Time.deltaTime * 20);

        if (rot_left == false && rot_right == false)
        {
            this.transform.Translate(Vector3.forward * v_key * Time.deltaTime * 4);
        }
        else
            // penalty for moving while rotating tank
            this.transform.Translate(Vector3.forward * v_key * Time.deltaTime * 2);

        if (rot_left)
            this.transform.Rotate(Vector3.up, Time.deltaTime * -20);
        if (rot_right)
            this.transform.Rotate(Vector3.up, Time.deltaTime * 20);
    }
}
