using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public float strength;
    private BoatMovement bm;
    private Collider2D trigger;

    private void Start()
    {
        trigger = GetComponent<CompositeCollider2D>();
    }

    private void FixedUpdate()
    {
        if (bm == null) return;
        if(bm.isInWall)
        {
            ColliderDistance2D dist = trigger.Distance(bm.gameObject.GetComponent<Collider2D>());
            bm.gameObject.GetComponent<Rigidbody2D>().AddForce(-dist.normal * dist.distance * strength,ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<BoatMovement>().isInWall = true;
            bm = other.gameObject.GetComponent<BoatMovement>();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<BoatMovement>().isInWall = false;
            bm = other.gameObject.GetComponent<BoatMovement>();
        }

    }
}
