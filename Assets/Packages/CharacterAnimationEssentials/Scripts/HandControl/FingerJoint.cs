using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    [System.Serializable]
    public class FingerJoint
    {

        public Vector3 rotation;

        public FingerJoint(Vector3 initialRotations)
        {
            rotation = initialRotations;
        }

    }

}