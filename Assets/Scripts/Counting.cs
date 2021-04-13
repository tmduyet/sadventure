using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counting : MonoBehaviour
{
    public float CurrentTime = 0f;
    public float StartTime = 300f;
    public Text Countingtext;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        Countingtext.text = CurrentTime.ToString("0");
        if(CurrentTime <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (CurrentTime < 10)
        {
            Countingtext.color = Color.red;
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
