using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{
    public class HandTransformDetection
    {

        // Sameruchan's finger naming style:
        //
        // "Index Distal.L"
        // "Middle Intermediate.R"

        // {Prefix}{FingerName}{JointName}{Suffix}

        string thumb = "Thumb_";
        string index = "Index_";
        string middle = "Middle_";
        string ring = "Ring_";
        string little = "Little_";

        string firstJointName = "Proximal";
        string secondJointName = "Intermediate";
        string thirdJointName = "Distal";

        string leftPrefix = "";
        string rightPrefix = "";

        string leftSuffix = "_L";
        string rightSuffix = "_R";

        Transform objectRoot;
        HandTransform handTransform;

        public HandTransformDetection(Transform objectRoot, HandTransform handTransform)
        {
            this.objectRoot = objectRoot;
            this.handTransform = handTransform;
        }


        public void Detect()
        {

            string prefix = handTransform.rightHand ? rightPrefix : leftPrefix;
            string suffix = handTransform.rightHand ? rightSuffix : leftSuffix;

            SetFinger(handTransform.thumb, prefix, thumb, suffix, handTransform.rightHand);
            SetFinger(handTransform.indexFinger, prefix, index, suffix, handTransform.rightHand);
            SetFinger(handTransform.middleFinger, prefix, middle, suffix, handTransform.rightHand);
            SetFinger(handTransform.ringFinger, prefix, ring, suffix, handTransform.rightHand);
            SetFinger(handTransform.littleFinger, prefix, little, suffix, handTransform.rightHand);

        }

        void SetFinger(FingerTransform fingerTransform, string prefix, string finger, string suffix, bool isRight)
        {
            fingerTransform.rightHand = isRight;

            fingerTransform.firstJoint = objectRoot.FirstChildOrDefault(x => x.name == $"{prefix}{finger}{thirdJointName}{suffix}");
            fingerTransform.secondJoint = objectRoot.FirstChildOrDefault(x => x.name == $"{prefix}{finger}{secondJointName}{suffix}");
            fingerTransform.thirdJoint = objectRoot.FirstChildOrDefault(x => x.name == $"{prefix}{finger}{firstJointName}{suffix}");
        }



    }

}