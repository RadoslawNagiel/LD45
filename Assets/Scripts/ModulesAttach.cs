using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulesAttach : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D " + GetInstanceID());

        ContactPoint2D contactPoint = getFirstContactPoint(collision);

        GameObject objectToAttach = collision.gameObject;
        Rigidbody2D otherRigidbody = objectToAttach.GetComponent<Rigidbody2D>();

        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        attachTo(joint, otherRigidbody);

        //GetComponent<Collider2D>().isTrigger = false;
    }

    private ContactPoint2D getFirstContactPoint(Collider2D sourceCollider)
    {
        ContactPoint2D[] contactPoints = new ContactPoint2D[1];
        sourceCollider.GetContacts(contactPoints);
        return contactPoints[0];
    }

    private void attachTo(HingeJoint2D joint, Rigidbody2D otherRigidbody)
    {
        joint.connectedBody = otherRigidbody;
        joint.autoConfigureConnectedAnchor = false;
        joint.enableCollision = false;
        joint.limits = new JointAngleLimits2D { min = -10, max = 10 };
    }
}
