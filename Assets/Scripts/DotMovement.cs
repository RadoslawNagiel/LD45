using System;
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
    {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        float Rotate = Input.GetAxis("RotateAxis");

        myRigidbody.velocity = new Vector2(
            MoveHorizontal * dotSpeed * Time.deltaTime,
            MoveVertical * dotSpeed * Time.deltaTime
        );
        myRigidbody.transform.Rotate(0, 0, Rotate * rotSpeed * Time.deltaTime);

    }
}
