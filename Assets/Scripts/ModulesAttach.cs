using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesAttach : MonoBehaviour
{
    [SerializeField] bool attachToMultiple = true;
    [SerializeField] int jointRange = 20;

    private bool IsAttached;

    void OnTriggerEnter2D(Collider2D collision)
    {
        ModulesAttach otherScript = collision.gameObject.GetComponent<ModulesAttach>();
        if (collision.gameObject.GetComponent<DotMovement>() == null &&
            (otherScript == null || !otherScript.IsAttached))
            return;

        GameObject objectToAttach = collision.gameObject;
        Rigidbody2D otherRigidbody = objectToAttach.GetComponent<Rigidbody2D>();

        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        attachTo(joint, otherRigidbody);

        GetComponent<Collider2D>().isTrigger = attachToMultiple;
        IsAttached = true;
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
