using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Enemy : MonoBehaviour
{
    public List<Transform> checkPointList;

    public int cpIndex;
    private Rigidbody2D rb;
    private BoatMovement bm;
    public float rotation = 0;
    private bool change = true;
    private Vector3 pos;
    public bool move = true;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        bm = GetComponent<BoatMovement>();
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
        if (change)
        {
            if (cpIndex > checkPointList.Count-1) cpIndex = 0;
            Transform[] objs = checkPointList[cpIndex].GetComponentsInChildren<Transform>();
            pos = objs[UnityEngine.Random.Range(0, objs.Length)].position;
            change = false;
        }

        Vector3 dir = pos - this.transform.position;
        
        Debug.DrawLine(this.transform.position,pos,Color.red,0.05f);
        dir.Normalize();
        rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    private void FixedUpdate()
    {
        Quaternion rot = bm.getRotation(rotation);
        rb.MoveRotation(rot);
        
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

    public void updateCP()
    {
        cpIndex++;
        change = true;
    }
}
