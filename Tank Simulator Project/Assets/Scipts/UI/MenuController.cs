using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject pauseUI;
    public GameObject LoseMenu;
    public GameObject WinMenu;

    public Player player;
    public CheckEnemyList enemyList;

    private AudioSource soundEffect = null;

    void Start()
    {
        if (this.GetComponent<AudioSource>() != null)
            soundEffect = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetHealth() <= 0)
        {
            Time.timeScale = 0;
            LoseMenu.SetActive(true);
        }

        if (enemyList.GetEnemyCount() == 0)
        {
            Time.timeScale = 0;
            WinMenu.SetActive(true);
        }
        
        // if escape key then pause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mainMenu.SetActive(Time.timeScale == 1);
            if (Time.timeScale == 1)
            {
                if (soundEffect != null)
                    soundEffect.Play();
                Time.timeScale = 0;
            }
            else
                Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseUI.SetActive(Time.timeScale == 1);
            if (Time.timeScale == 1)
            {
                if (soundEffect != null)
                    soundEffect.Play();
                Time.timeScale = 0;
            }
            else
                Time.timeScale = 1;
        }
    }

    private void showLoseGame()
    {

    }

    public void OnResume()
    {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        Debug.Log("test");
    }

    public void OnExitGame()
    {


    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
