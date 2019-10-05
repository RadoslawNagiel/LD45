using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotMovement : MonoBehaviour
{
    [SerializeField] float dotSpeed = 5f; 

    Vector2 pos;
        
    void FixedUpdate()
    {
        pos = transform.position;

        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        pos.x += MoveHorizontal * Time.deltaTime * dotSpeed;
        pos.y += MoveVertical * Time.deltaTime * dotSpeed;

        transform.position = pos; 
    }
}
