using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player1"))
        {
            SoundManager.listen("Death");
            StartCoroutine(Death());

        }
        if (collision.collider.CompareTag("Player2"))
        {
            SoundManager.listen("Death");
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return 0;
    }
}
