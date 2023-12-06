using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;

    private AudioSource soundEffect = null;

    void Start()
    {
        if (this.GetComponent<AudioSource>() != null)
            soundEffect = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // if escape key then pause
        if (Input.GetKeyDown(KeyCode.F1))
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
