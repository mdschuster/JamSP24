using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{

    [Header("Movement Properties")] 
    public float maxSpeed;
    public float maxAcceleration;
    public float rotationSpeed;
    public bool isInWall = false;
    
    private void Start()
    {
        
    }


    public Quaternion getRotation(float angle)
    {
        Quaternion desiredRotation = Quaternion.AngleAxis(angle+90f, Vector3.forward);
        desiredRotation.Normalize();
        return Quaternion.Lerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }

    public Vector2 getMovement()
    {
        return  maxAcceleration * Time.deltaTime * -transform.up;
    }

}
