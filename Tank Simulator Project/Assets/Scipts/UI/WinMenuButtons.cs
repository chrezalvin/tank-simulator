using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenuButtons : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void GotoNextLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void RestartLastLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
