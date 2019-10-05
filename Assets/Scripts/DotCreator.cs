using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotCreator : MonoBehaviour
{
    public GameObject dot;

    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))
        {
            dot.GetComponent<DotMovement>().enabled = true;
            dot.GetComponent<SpriteRenderer>().enabled = true;
            enabled = false;
        }
    }
}
