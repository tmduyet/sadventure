using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1NestLvTrigger : MonoBehaviour
{
    public float Radius;
    public Transform player1checkpoint;

    public bool TriggerPoint1;

    public LayerMask WhatisHit1;
    // Start is called before the first frame update
    void Start()
    {
        player1checkpoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerPoint1 = Physics2D.OverlapCircle(player1checkpoint.position, Radius, WhatisHit1);
    }
}
