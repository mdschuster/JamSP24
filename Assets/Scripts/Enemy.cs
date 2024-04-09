using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Transform> checkPointList;

    public int cpIndex;
    private Rigidbody2D rb;
    private BoatMovement bm;
    public float rotation = 0;

    public bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        bm = GetComponent<BoatMovement>();
        cpIndex = 0;
        rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!move)
        {
            return;
        }
        //point to next checkpoint
        Vector3 dir = checkPointList[cpIndex].position-this.transform.position;
        if (dir.magnitude < 2f) cpIndex++;
        
        if (cpIndex > checkPointList.Count) cpIndex = 0;
        Debug.DrawLine(this.transform.position,checkPointList[cpIndex].position,Color.red,0.05f);
        dir.Normalize();
        rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        transform.rotation = bm.getRotation(rotation);
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
