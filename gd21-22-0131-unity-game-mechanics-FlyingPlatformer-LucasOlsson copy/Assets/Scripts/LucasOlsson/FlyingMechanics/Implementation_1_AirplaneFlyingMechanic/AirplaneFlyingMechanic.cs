using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneFlyingMechanic : MonoBehaviour
{
    public float speed;
    public float acceleration;
    public float rotationControl;
    
    public Rigidbody2D airPlaneBody;
    private float movY, movX = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        airPlaneBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movY = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 planeMovement = (movX * acceleration)* transform.right ;
        airPlaneBody.AddForce(planeMovement);
        
        float planeDirection = Vector2.Dot(airPlaneBody.velocity, airPlaneBody.GetRelativeVector(Vector2.right));

        if(acceleration > 0)
        {
            if(planeDirection > 0)
            {
                airPlaneBody.rotation += movY * rotationControl * (airPlaneBody.velocity.magnitude / speed);
            }
            else
            {
                airPlaneBody.rotation -= movY * rotationControl * (airPlaneBody.velocity.magnitude / speed);
            }
        }

        float thrustForce = Vector2.Dot(airPlaneBody.velocity, airPlaneBody.GetRelativeVector(Vector2.down)) * 2.0f;
        
        Vector2 relForce = Vector2.up * thrustForce;
        
        airPlaneBody.AddForce((airPlaneBody.GetRelativeVector(relForce)));
        
        if (airPlaneBody.velocity.magnitude > speed)
        {
            airPlaneBody.velocity = airPlaneBody.velocity.normalized * speed;
        }
    }
}
