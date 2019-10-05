﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMovement : MonoBehaviour
{
    [SerializeField] float dotSpeed = 5f; 
    [SerializeField] float rotSpeed = 5f; 

    Rigidbody2D myRigidbody;
    
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {/*
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        if (Math.Abs(MoveHorizontal) < 0.1f && Math.Abs(MoveVertical) < 0.1f)
        {
            myRigidbody.isKinematic = true;
        }
        else
        {
            myRigidbody.isKinematic = false;
        }

        myRigidbody.velocity = new Vector2(
            MoveHorizontal * dotSpeed * Time.deltaTime,
            MoveVertical * dotSpeed * Time.deltaTime
        );*/

        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        if (Math.Abs(MoveVertical) < 0.1f)
        {
            myRigidbody.isKinematic = true;
        }
        else
        {
            myRigidbody.isKinematic = false;
        }
        
        myRigidbody.velocity = transform.up * MoveVertical * dotSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -MoveHorizontal * rotSpeed * Time.deltaTime);

    }
}
