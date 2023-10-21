using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowPath : MonoBehaviour
{
    public GameObject enemyModel;
    public List<Transform> path;

    public int moveSpeed = 5;
    public int rotateSpeed = 20;

    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        enemyModel.transform.position = path[index].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyModel == null) return;

        Vector3 tankToPlayer = path[index].transform.position - enemyModel.transform.position;
        //Quaternion toRotation = Quaternion.LookRotation(new Vector3(enemyModel.transform.position.x, tankToPlayer.y, enemyModel.transform.position.z));
        Quaternion toRotation = Quaternion.LookRotation(new Vector3(tankToPlayer.x, 0, tankToPlayer.z));

        // if angle is fine, then move
        if (Mathf.Abs(Quaternion.Dot(enemyModel.transform.rotation, toRotation)) > 0.99f)
        {
            enemyModel.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.Self);

        }
        else
        {
            // otherwise keep rotating
            enemyModel.transform.rotation = Quaternion.Lerp(enemyModel.transform.rotation, toRotation, rotateSpeed * Mathf.PI * Time.deltaTime / 180);
        }

        if (Vector3.Distance(path[index].transform.position, enemyModel.transform.position) < 0.5f)
        {
            index = (index + 1) == path.Count ? 0 : index + 1;
        }
    }
}
