using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesAttach : MonoBehaviour
{
    [SerializeField] bool attachToMultiple = true;
    [SerializeField] int jointRange = 20;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<ModulesAttach>() == null)
            return;

        GameObject objectToAttach = collision.gameObject;
        Rigidbody2D otherRigidbody = objectToAttach.GetComponent<Rigidbody2D>();

        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        attachTo(joint, otherRigidbody);

        GetComponent<Collider2D>().isTrigger = attachToMultiple;
    }

    private void attachTo(HingeJoint2D joint, Rigidbody2D otherRigidbody)
    {
        joint.connectedBody = otherRigidbody;
        joint.autoConfigureConnectedAnchor = false;
        joint.enableCollision = false;

        int halfRange = jointRange / 2;
        joint.limits = new JointAngleLimits2D { min = -halfRange, max = halfRange };
    }
}
