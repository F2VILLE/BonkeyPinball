using UnityEngine;

public class Flips : MonoBehaviour
{
    [SerializeField] private HingeJoint flipLeftJoint;
    [SerializeField] private HingeJoint flipRightJoint;
    [SerializeField] private float flipForce = 1500f;
    [SerializeField] private float flipReturnForce = 500f;

    void Start()
    {
        SetupJoint(flipLeftJoint);
        SetupJoint(flipRightJoint);
    }

    void Update()
    {
        UpdateFlipper(flipLeftJoint, Input.GetKey(KeyCode.LeftArrow), true);
        UpdateFlipper(flipRightJoint, Input.GetKey(KeyCode.RightArrow), false);
    }

    void SetupJoint(HingeJoint joint)
    {
        if (joint == null) return;
        joint.useMotor = true;
        joint.useLimits = true;
    }

    void UpdateFlipper(HingeJoint joint, bool pressed, bool isLeft)
    {
        if (joint == null) return;

        JointMotor motor = joint.motor;
        motor.force = flipForce;
        motor.targetVelocity = pressed ? (isLeft ? -flipForce : flipForce) : (isLeft ? flipReturnForce : -flipReturnForce);
        joint.motor = motor;
    }

}
