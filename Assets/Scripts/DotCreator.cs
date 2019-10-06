using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotCreator : MonoBehaviour
{

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetButton("Fire2") || Input.GetButton("Fire3"))
        {
            GetComponent<Animator>().Play("DotAnim");
            GetComponent<DotMovement>().enabled = true;
            enabled = false;
        }
    }
}
