using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private int place = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().midpoint = false;
            other.GetComponent<Player>().finalPlace = place;
            place++;
        }

        if (other.CompareTag("Enemy"))
        {
            place++;
        }
    }
}
