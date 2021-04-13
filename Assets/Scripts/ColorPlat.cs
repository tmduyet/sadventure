using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPlat : MonoBehaviour
{
    public Animator ani;
    public bool IsBlue = false;
    public bool IsOrange = false;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    void anime()
    {
        ani.SetBool("IsBlue", IsBlue);
        ani.SetBool("IsOrange", IsOrange);
    }
    // Update is called once per frame
    void Update()
    {

        if(IsBlue)
        {
            gameObject.layer = 11;
        }
        if (IsOrange)
        {
            gameObject.layer = 12;
        }
        anime();
    }
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player1"))
        {
            IsOrange = true;
        }
        else if (collision.collider.CompareTag("Player2"))
        {
            IsBlue = true;
        }
    }
}
