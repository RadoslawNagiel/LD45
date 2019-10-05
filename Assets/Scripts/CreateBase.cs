using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBase : MonoBehaviour
{
    public void Create()
    {
        gameObject.GetComponent<Points>().ChangePoint("Shield", -5);
        gameObject.GetComponent<Points>().ChangePoint("Spike", -5);
        gameObject.GetComponent<Points>().ChangePoint("Life", -5);
        GameObject Obj = (GameObject)Instantiate(Resources.Load("Base"), transform.position, transform.rotation);
    }
}
