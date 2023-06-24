﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
/*    public float moveSpeed = 3;
    public float leftRightSpeed = 4;*/
    public float forwardSpeed;
    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 4;//the distance between two lanes

    public float jumpForce;
    public float Gravity = -20;
    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        controller.Move(direction * Time.fixedDeltaTime);
        direction.z = forwardSpeed;

        
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }
        else
        {
            direction.y += Gravity * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance; 
        }

        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position,targetPosition,80*Time.deltaTime);

    }

 /*   private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }*/


    private void Jump()
    {
        direction.y = jumpForce;
    }

}