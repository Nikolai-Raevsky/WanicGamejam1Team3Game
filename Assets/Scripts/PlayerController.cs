﻿/////By Cooper Spring
/////Date : 11/3/2020
////This is a movement script to move the player with input, using tank controls for now

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEditor;
using Unity.Mathematics;
using UnityEditorInternal;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10;
    public float TurnSpeed = 10f;
    Rigidbody2D myRB;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    
    //Vector3 startingUp;
    //Vector3 startingRight;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    
    // Update is called once per frame
    void Update()
    {
        //get the input from player
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

       
    }

    private void FixedUpdate()
    {
        //set velocity to input
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            //limit the diagonal movespeed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        //set the velocity of the player to the input values
        myRB.velocity = new Vector2(horizontal * Speed, vertical * Speed).normalized;

        //temporary method of setting direction rotation, may be changed for efficiency
        //try a switch if it isn't bugging out later (compiler error only in unity)
        //for the switch, use bool negativePressH/V, PressH/V, and notPressedH/V declared at top, make sure to reset at end of update
        /*
         if(horizontal > 0)
         {
            PressH = true;
         }
         else if(horizontal < 0)
         {
            negativePressH = true;
         }
         else
         {
            notPressedH = true;
         }
         
         And Et Cetera...
         */
        if (horizontal > 0 && vertical == 0)
        {
            myRB.SetRotation(0);
        }

        if (horizontal > 0 && vertical > 0)
        {
            myRB.SetRotation(45);
        }

        if (horizontal == 0 && vertical > 0)
        {
            myRB.SetRotation(90);
        }

        if (horizontal < 0 && vertical > 0)
        {
            myRB.SetRotation(135);
        }

        if (horizontal < 0 && vertical == 0)
        {
            myRB.SetRotation(180);
        }

        if (horizontal < 0 && vertical < 0)
        {
            myRB.SetRotation(225);
        }

        if (horizontal == 0 && vertical < 0)
        {
            myRB.SetRotation(270);
        }

        if (horizontal > 0 && vertical < 0)
        {
            myRB.SetRotation(315);
        }

        
    }
}
