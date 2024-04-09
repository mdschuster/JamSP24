using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> checkPointList;

    private int cpIndex;
    private Rigidbody2D rb;
    private BoatMovement bm;

    public bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        bm = GetComponent<BoatMovement>();
        cpIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
        {
            return;
        }
        //point to next checkpoint
    }

    private void FixedUpdate()
    {
        if (move)
        {
            Vector2 movement = bm.getMovement();
            rb.AddForce(movement,ForceMode2D.Force);
            if (rb.velocity.magnitude > bm.maxSpeed)
            {
                float breakSpeed = rb.velocity.magnitude - bm.maxSpeed;
                Vector3 breakVel = rb.velocity.normalized * breakSpeed;
                rb.AddForce(-breakVel);
            }
        } 
        else
        {
            //slow down
            rb.AddForce(-rb.velocity,ForceMode2D.Force);
            if (rb.velocity.magnitude < 0.1f) rb.velocity = Vector3.zero;
        }
    }
}
