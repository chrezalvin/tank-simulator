using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckEnemyList : MonoBehaviour
{

    public int winningSceneId;
    int CountChildren(Transform a)
    {
        int count = 0;
        foreach(var children in a)
            ++count;
        return count;
    }

    private int enemyCount;

    public int GetEnemyCount()
    {
        return enemyCount;
    }

    public void ReportEnemyDestroyed()
    {
        --enemyCount;
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = CountChildren(this.transform);
        Debug.Log("There are " + enemyCount + " enemies");
    }
}
