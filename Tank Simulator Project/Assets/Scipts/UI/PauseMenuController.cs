using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;

    private AudioSource soundEffect = null;

    void Start()
    {
        if(this.GetComponent<AudioSource>() != null)
            soundEffect = this.GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        // pause game without showing menu
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.SetActive(Time.timeScale == 1);
            if (Time.timeScale == 1)
            {
                if(soundEffect != null)
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
        pauseMenu.SetActive(false);
    }
}
