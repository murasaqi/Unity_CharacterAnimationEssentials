using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    [System.Serializable]
    public class Finger
    {
        public FingerJoint firstJoint = new FingerJoint(Vector3.zero);
        public FingerJoint secondJoint = new FingerJoint(Vector3.zero);
        public FingerJoint thirdJoint = new FingerJoint(Vector3.zero);

        public Finger()
        {
            firstJoint = new FingerJoint(Vector3.zero);
            secondJoint = new FingerJoint(Vector3.zero);
            thirdJoint = new FingerJoint(Vector3.zero);
        }

        public static Finger operator *(Finger finger, float weight)
        {
            Finger f = new Finger();
            f.firstJoint.rotation = finger.firstJoint.rotation * weight;
            f.secondJoint.rotation = finger.secondJoint.rotation * weight;
            f.thirdJoint.rotation = finger.thirdJoint.rotation * weight;

            return f;
        }

        public static Finger operator +(Finger finger1, Finger finger2)
        {
            Finger f = new Finger();
            f.firstJoint.rotation = finger1.firstJoint.rotation + finger2.firstJoint.rotation;
            f.secondJoint.rotation = finger1.secondJoint.rotation + finger2.secondJoint.rotation;
            f.thirdJoint.rotation = finger1.thirdJoint.rotation + finger2.thirdJoint.rotation;

            return f;
        }
    }

}