using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameOnClick : MonoBehaviour
{
    public int sceneId;

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneId);
    }
}
