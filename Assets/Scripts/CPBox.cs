using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPBox : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.GetComponent<Enemy>().cpIndex == id)
            {
                other.GetComponent<Enemy>().updateCP();
            }
        }
    }
}
