using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapear : MonoBehaviour
{
    public float delaytime = 0.5f;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player1")|| collision.collider.CompareTag("Player2"))
        {
            StartCoroutine(disappear());
        }
    }
    IEnumerator disappear()
    {
        yield return new WaitForSeconds(delaytime);
        gameObject.SetActive(false);
        yield return 0;
           
    }

}
