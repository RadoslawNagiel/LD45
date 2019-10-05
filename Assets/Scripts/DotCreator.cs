using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotCreator : MonoBehaviour
{
    public GameObject dot;

    private bool dotActivated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !dotActivated)
        {
            dot.SetActive(true);
            dotActivated = true;
        }
    }
}
