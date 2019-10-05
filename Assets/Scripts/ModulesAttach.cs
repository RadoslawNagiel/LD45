using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesAttach : MonoBehaviour
{
    private Rigidbody2D selfRigidbody;

    void Start()
    {
        selfRigidbody = GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        GameObject module = collision.gameObject;

        FixedJoint2D joint = module.AddComponent<FixedJoint2D>();
        joint.connectedBody = selfRigidbody;
        joint.enableCollision = false;

        Destroy(module.GetComponent<Collider2D>());
    }
}
