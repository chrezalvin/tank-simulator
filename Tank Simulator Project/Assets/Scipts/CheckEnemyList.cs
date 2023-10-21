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

    public void ReportEnemyDestroyed()
    {
        --enemyCount;

        if(enemyCount == 0)
            SceneManager.LoadScene(winningSceneId);
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyCount = CountChildren(this.transform);
        Debug.Log("There are " + enemyCount + " enemies");
    }
}
