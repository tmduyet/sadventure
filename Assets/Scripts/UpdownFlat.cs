using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdownFlat : MonoBehaviour
{
    public Rigidbody2D rig2d;
    [SerializeField]
    private float speed;
    public Player1 player1;
    // Start is called before the first frame update
    void Start()
    {
        rig2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updown();
    }
    void updown()
    {
        Vector3 trans = transform.localPosition;
        trans.y += speed;
        transform.localPosition = trans;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Vacham"))
        {
            speed *= -1;
        }
    }
}
