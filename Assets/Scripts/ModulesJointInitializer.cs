using UnityEngine;
using System.Collections;

public class ModulesJointAttacher
{
    public void MakeJointBetween(GameObject gameObject, Rigidbody2D other)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.connectedBody = other;
        joint.autoConfigureConnectedAnchor = false;
        joint.enableCollision = false;
        joint.limits = makeJointLimits();
    }

    private JointAngleLimits2D makeJointLimits() => new JointAngleLimits2D
    {
        min = -10,
        max = 10
    };
}
