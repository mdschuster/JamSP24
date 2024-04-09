using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera mainCamera;
    private BoatMovement bm;
    private Vector3 mousePos;
    private Vector2 dirToMouse;
    private Rigidbody2D rb;
    private bool move = false;
    private int rotation = 0;
    public bool midpoint = false;
    public int finalPlace = -1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        finalPlace = -1;
        midpoint = false;
        bm = GetComponent<BoatMovement>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        dirToMouse = mousePos - this.transform.position;
        dirToMouse.Normalize();
        if (finalPlace != -1)
        {
            move = false;
            return;
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            rotation += 3;
        } else if (Input.GetKey(KeyCode.D))
        {
            rotation += -3;
        }

        if (Input.GetKey(KeyCode.W))
        {
            move = true;
        }
        else
        {
            move = false;
        }



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
