using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIspause = true;
    public GameObject PausemenuUI;
    public GameObject Optionui;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           
            if(gameIspause)
            {
                pause();
            }
            else
            {
                resume();
            }
        }
    }
    public void resume()
    {
        PausemenuUI.SetActive(false);
        if(Optionui)
        {
            Optionui.SetActive(false);
        }
        Time.timeScale = 1f;
        gameIspause = true;
    }
    void pause()
    {
        PausemenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIspause = false;
    }
    public void Quit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");   

    }
}
