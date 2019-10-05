using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesAttach : MonoBehaviour
{
    public ModulesJointAttacher modulesJointFactory = new ModulesJointAttacher();

    private Rigidbody2D selfRigidbody;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");

        GameObject module = collision.gameObject;
        modulesJointFactory.MakeJointBetween(module, selfRigidbody);

        Destroy(module.GetComponent<Collider2D>());
    }

    
}
