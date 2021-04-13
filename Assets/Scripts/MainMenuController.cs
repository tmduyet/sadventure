using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Text tx;
    bool e = true;

    public void StartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void Loadgame()
    {
        SceneManager.LoadScene(Save.Lv);
    }
    public void GameExit()
    {
        Application.Quit();
    }
    IEnumerator color()
    {
        yield return new WaitForSeconds(0.5f);
        tx.color = Random.ColorHSV();
    }
}
