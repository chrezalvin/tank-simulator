using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraZoom : MonoBehaviour
{
    public Transform player;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(player.position, this.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(Vector3.Distance(player.position, transform.position));

        if (wheel < 0 && distance <= Vector3.Distance(player.position, transform.position))
            this.transform.Translate(Vector3.forward * -3);
        if (wheel > 0 && distance + 20 >= Vector3.Distance(player.position, transform.position))
            this.transform.Translate(Vector3.forward * 3);
    }
}
