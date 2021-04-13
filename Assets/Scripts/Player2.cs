using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float Speed = 40f;
    public float Jumppow = 300f;
    public Rigidbody2D rig2d;
    public float move;
    private bool facingright = true;
    public Transform GroundcheckPoint;
    public float Groundcheckradius;
    public LayerMask WhatisGround;
    public Animator ani;
    public AudioSource Walking;
    public bool Ismoving = false;

    public bool ground;
    // Start is called before the first frame update
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        Walking = GetComponent<AudioSource>();
        
    }
    void anime()
    {
        ani.SetFloat("Speed", Mathf.Abs(rig2d.velocity.x));
        ani.SetBool("Ground", ground);
        ani.SetFloat("Vspeed", rig2d.velocity.y);
    }
    // Update is called once per frame
    void Update()
    {
        anime();
        ground = Physics2D.OverlapCircle(GroundcheckPoint.position, Groundcheckradius, WhatisGround);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (ground)
            {
                SoundManager.listen("Jump");
                rig2d.AddForce(Vector2.up * Jumppow);
                   rig2d.velocity = new Vector2(rig2d.velocity.x * 0.9f, rig2d.velocity.y);
            }

        }
    }
    public void FixedUpdate()
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

            move = Input.GetAxis("Player2");
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
        if (collision.gameObject.name.Equals("MovingPlat"))
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
