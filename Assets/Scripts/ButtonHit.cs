using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    public Animator ani;
    public bool hit;
    public Transform Playercheckpoint;
    public float Playercheckradius;
    public LayerMask whoisplayer;
    public List<GameObject> platan;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        
        
    }

    void anime()
    {
        ani.SetBool("Hit", hit);
    }
    // Update is called once per frame
    void Update()
    {
        anime();
        hit = Physics2D.OverlapCircle(Playercheckpoint.position, Playercheckradius, whoisplayer);
        if (hit)
        {
           
            for (int i = 0; i < platan.Count; i++)
            {
                platan[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < platan.Count; i++)
            {
                platan[i].SetActive(false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player1")|| collision.collider.CompareTag("Player2"))
        {
            SoundManager.listen("button");
        }
    }
}
