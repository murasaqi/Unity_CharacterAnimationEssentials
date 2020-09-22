using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    [System.Serializable]
    public class FingerTransform
    {
        public bool rightHand = false;

        public Transform firstJoint;
        public Transform secondJoint;
        public Transform thirdJoint;

        public void Set(Finger finger)
        {
            firstJoint.localRotation = Quaternion.Euler(rightHand ? Invert(finger.firstJoint.rotation) : finger.firstJoint.rotation);
            secondJoint.localRotation = Quaternion.Euler(rightHand ? Invert(finger.secondJoint.rotation) : finger.secondJoint.rotation);
            thirdJoint.localRotation = Quaternion.Euler(rightHand ? Invert(finger.thirdJoint.rotation) : finger.thirdJoint.rotation);
        }

        Vector3 Invert(Vector3 input)
        {
            return new Vector3(input.x, -input.y, -input.z);
        }

    }

}