﻿/*  Unity Script for Player Movement
 *  by Gabriel Cruceanu for Group Project 2 game "Rise Against the Cuisine"
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 0.5f;
    public float gravity = -4.91f;
    public float jumpHeight = 0.5f;
        
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    public float slowTime=0;

    private bool sprint = false;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (slowTime>0)
            speed = 0.2f; ;

        slowTime -= Time.deltaTime;

        if (slowTime <= 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
                speed = 1f;
            else speed = 0.5f;
        }

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpiderBullet"))
            slowTime = 5f;
    }
}