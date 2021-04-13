using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlat : MonoBehaviour
{
    public Animator ani;
    public bool changeBlue = true;
    public bool run = true;
    public float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();

        StartCoroutine(change());
    }

    private void Update()
    {

        
    }

    // Update is called once per frame
    void anime()
    {
        ani.SetBool("Change", changeBlue);
    }
    IEnumerator change()
    {
        while (run)
        {
            yield return new WaitForSeconds(delay);
            if (changeBlue)
            {
                changeBlue = !changeBlue;
                gameObject.layer = 11;
                anime();
            }
            yield return new WaitForSeconds(delay);
            if (!changeBlue)
            {
                changeBlue = !changeBlue;
                gameObject.layer = 12;
                anime();
            }
        }
    }
  
    
}
