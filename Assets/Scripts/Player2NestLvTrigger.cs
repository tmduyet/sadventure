using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2NestLvTrigger : MonoBehaviour
{
    public float Radius;
    public Transform player2checkpoint;

    public bool TriggerPoint2;

    public LayerMask WhatisHit;
    // Start is called before the first frame update
    void Start()
    {
        player2checkpoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        TriggerPoint2 = Physics2D.OverlapCircle(player2checkpoint.position, Radius, WhatisHit);
    }
}
