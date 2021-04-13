using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGate1 : MonoBehaviour
{
    public Animator ani;
    public bool hit = false;
    public GameObject Torch;
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anime();
        if(hit)
        {
            Torch.SetActive(true);
        }
    }

    void anime()
    {
        ani.SetBool("Hit", hit);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player1") || collision.collider.CompareTag("Player2"))
        {
            SoundManager.listen("button");
            hit = true;
        }
    }
}
