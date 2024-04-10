using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPBoxTele : MonoBehaviour
{
    public Transform[] teleLocation;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.transform.position = teleLocation[Random.Range(0,teleLocation.Length)].position;
        }
    }
}
