using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DOOR : MonoBehaviour
{
    public bool player1hit;
    public bool player2hit;
    public LayerMask Whatisplayer1;
    public LayerMask Whatisplayer2;
    public float Radius;
    public Transform TriggerPos;
    public GameObject touch1;
    public GameObject touch2;
    public bool playerTouch1;
    public bool playerTouch2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player1hit = Physics2D.OverlapCircle(TriggerPos.position, Radius, Whatisplayer1);
        player2hit = Physics2D.OverlapCircle(TriggerPos.position, Radius, Whatisplayer2);
        if(touch1.activeSelf)
        {
            playerTouch1 = true;
        }
        if (touch2.activeSelf)
        {
            playerTouch2 = true;
        }
        if(player1hit && player2hit && playerTouch1 && playerTouch2)
        {
            SceneManager.LoadScene("Thanks");
        }
    }
}
