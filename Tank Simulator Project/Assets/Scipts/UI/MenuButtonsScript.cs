using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour
{
    public GameObject mainMenu;
    public int mainMenuSceneId = 0;

    // on this open, then pause game
    private void Start()
    {
        Time.timeScale = 0;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GotoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(mainMenuSceneId);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }

    public void GoToScene(int sceneIndex)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex);
    }


}
