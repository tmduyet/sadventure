using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float Speed = 40f;
    public float Jumppow = 300f;
    public Rigidbody2D rig2d;
    public float move;
    private bool facingright = true;
    public Transform Groundcheckpoint;
    public float GroundcheckRadius;
    public LayerMask WhatisGround;
    public bool ground;
    public Animator ani;
    public AudioSource Walking;
    public bool Ismoving = false;

    // Start is called before the first frame update
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        Walking = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void anime()
    {
        ani.SetFloat("Speed",Mathf.Abs( rig2d.velocity.x));
        ani.SetBool("Ground", ground);
        ani.SetFloat("Vspeed", rig2d.velocity.y);
    }
    void Update()
    {

        anime();
        ground = Physics2D.OverlapCircle(Groundcheckpoint.position, GroundcheckRadius, WhatisGround);
        
            if (Input.GetKeyDown(KeyCode.W))
        {
            if (ground)  
            {
                SoundManager.listen("Jump");
                  rig2d.AddForce(Vector2.up * Jumppow);
                    rig2d.velocity = new Vector2(rig2d.velocity.x * 0.9f, rig2d.velocity.y);
          
            }
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rig2d.velocity.x) > 2f)
        {
            Ismoving = true;
        }
        else Ismoving = false;
        if (Ismoving && ground)
        {
            if (!Walking.isPlaying)
                Walking.Play();
        }
        else
            Walking.Stop();

        move = Input.GetAxis("Player1");    
            rig2d.AddForce(Vector2.right * move * Speed);
            rig2d.velocity = new Vector2(rig2d.velocity.x * 0.9f, rig2d.velocity.y);

  
        if (move < 0 && facingright)
        {
            facing();
        }
        if (move > 0 && !facingright)
        {
            facing();
        }

    }

    void facing()
    {
        facingright = !facingright;
        Vector3 tranf = transform.localScale;
        tranf.x *= -1;
        transform.localScale = tranf;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("MovingPlat"))
        {
            this.transform.parent = collision.transform;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("MovingPlat"))
        {
            this.transform.parent = null;
        }
    }
}
