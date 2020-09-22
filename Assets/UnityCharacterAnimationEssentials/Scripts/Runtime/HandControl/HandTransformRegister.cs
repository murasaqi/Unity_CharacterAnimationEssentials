using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    public class HandTransformRegister : MonoBehaviour
    {

        public Transform skeletonRoot;

        public HandTransform rightHandTransform;
        public HandTransform leftHandTransform;

        public void Start()
        {
            rightHandTransform.Initialize();
            leftHandTransform.Initialize();
        }

        public void OnValidate()
        {
            rightHandTransform.rightHand = true;
        }

        public void Reset()
        {
            rightHandTransform = new HandTransform();
            rightHandTransform.rightHand = true;

            leftHandTransform = new HandTransform();

            DetectHandJoints();
        }

#if UNITY_EDITOR
        public void DetectHandJoints()
        {

            HandTransformDetection leftHandDetection = new HandTransformDetection(skeletonRoot, leftHandTransform);
            HandTransformDetection rightHandDetection = new HandTransformDetection(skeletonRoot, rightHandTransform);

            leftHandDetection.Detect();
            rightHandDetection.Detect();
        }
#endif

    }

}