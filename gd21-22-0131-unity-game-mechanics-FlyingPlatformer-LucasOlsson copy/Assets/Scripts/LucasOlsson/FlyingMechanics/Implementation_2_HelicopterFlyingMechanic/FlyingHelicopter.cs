using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class FlyingHelicopter : MonoBehaviour
{
    public float engineSpeed;
    public float rotationForce;
    public float rotationsSpeed;
    private Rigidbody helicopterBody;
    public Vector2 movement;
    public float minSpeed;
    public float maxSpeed;

    //for propellers
    public Transform propellers;
    public float maxPropSpeed = 2000;
    private float currentFanSpeed;    

    private void Start()
    {
        helicopterBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // movement.x = Input.GetAxisRaw("Horizontal");
        // movement.y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MoveHelicopter(movement);
        RotationHelicopter();
        FlipCharacter();
    }


    private void MoveLimit()
    {
        //Hämtar velocity som vi har nu
        var velocity = helicopterBody.velocity;
        //här begränsar vi hastigheten. 
        velocity = velocity.normalized * Mathf.Clamp(velocity.magnitude, min:minSpeed, max:maxSpeed);
        
        helicopterBody.velocity = velocity;
    }
    private void MoveHelicopter(Vector2 direction)
    {
        //movement
        helicopterBody.AddForce(direction * engineSpeed);
        
        //propellers rotation
        propellers.Rotate(0, currentFanSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.W))
        {
            currentFanSpeed = Mathf.Lerp(currentFanSpeed, maxPropSpeed, Time.deltaTime);
        }
        else
        {
            currentFanSpeed = Mathf.Lerp(currentFanSpeed, 0, Time.deltaTime);
        }
    }

    private void RotationHelicopter()
    {
        if (Input.GetKey(KeyCode.D))
        {
            
            rotationForce -= rotationsSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rotationForce += rotationsSpeed * Time.deltaTime;
        }
        rotationForce = Mathf.Clamp(rotationForce, -15, 15);
        var rot = transform.localEulerAngles;
        rot.z = rotationForce;
        transform.localEulerAngles = rot;
    }

    private void FlipCharacter()
    {
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }

        transform.localScale = characterScale;
    }
}