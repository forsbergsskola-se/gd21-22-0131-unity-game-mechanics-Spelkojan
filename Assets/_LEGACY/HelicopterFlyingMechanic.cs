using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterFlyingMechanic : MonoBehaviour
{
  public float engineSpeedY;
  public float engineSpeedX;
  public float rotationForce;
  public float rotationsSpeed;
  private Rigidbody2D helicopterBody;
  public Vector2 movement;
  
  private void Start()
  {
    helicopterBody = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
  }

  private void FixedUpdate()
  {
    moveHelicopter(movement);
    // rotationHelicopter();
    FlipCharacter();
  }

  private void moveHelicopter(Vector2 direction)
  {
    // helicopterBody.MovePosition(helicopterBody.position + movement * engineSpeed * Time.fixedDeltaTime);
    if (Input.GetAxisRaw("Horizontal") != 0) {
      helicopterBody.MovePosition(helicopterBody.position + movement * engineSpeedX * Time.deltaTime);
    }
    if (Input.GetAxisRaw("Vertical") != 0) {
      helicopterBody.MovePosition(helicopterBody.position + movement * engineSpeedY * Time.deltaTime);
    }
  }

  // private void rotationHelicopter()
  // {
  //     if (Input.GetKey(KeyCode.D))
  //     {
  //         // transform.Rotate(Vector3.back * rotationForce * Time.deltaTime);
  //         rotationForce -= rotationsSpeed * Time.deltaTime;
  //     }
  //     if (Input.GetKey(KeyCode.A))
  //     {
  //         // transform.Rotate(Vector3.forward * rotationForce * Time.deltaTime);
  //         rotationForce += rotationsSpeed * Time.deltaTime;
  //     }
  //     rotationForce = Mathf.Clamp(rotationForce, -15, 15);
  //     var rot = transform.localEulerAngles;
  //     rot.z = rotationForce;
  //     transform.localEulerAngles = rot;
  // }
  
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
