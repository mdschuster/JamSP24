using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public float strength;
    //private BoatMovement bm;
    private Collider2D trigger;
    private List<BoatMovement> boats;

    private void Start()
    {
        boats = new List<BoatMovement>();
        trigger = GetComponent<CompositeCollider2D>();
    }

    private void FixedUpdate()
    {
        foreach (BoatMovement b in boats)
        {
            if (b.isInWall)
            {
                ColliderDistance2D dist = trigger.Distance(b.gameObject.GetComponent<Collider2D>());
                b.gameObject.GetComponent<Rigidbody2D>()
                    .AddForce(-dist.normal * dist.distance * strength, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<BoatMovement>().isInWall = true;
            boats.Add(other.gameObject.GetComponent<BoatMovement>());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<BoatMovement>().isInWall = false;
            boats.Remove(other.gameObject.GetComponent<BoatMovement>());
        }

    }
}
