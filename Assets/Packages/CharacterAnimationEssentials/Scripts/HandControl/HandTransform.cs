using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    [System.Serializable]
    public class HandTransform
    {
        public bool rightHand = false;

        public FingerTransform thumb;
        public FingerTransform indexFinger;
        public FingerTransform middleFinger;
        public FingerTransform ringFinger;
        public FingerTransform littleFinger;

        public void Initialize()
        {
            thumb.rightHand = rightHand;
            indexFinger.rightHand = rightHand;
            middleFinger.rightHand = rightHand;
            ringFinger.rightHand = rightHand;
            littleFinger.rightHand = rightHand;
        }


        public void Set(SingleHandShape hand)
        {
            thumb.Set(hand.thumb);
            indexFinger.Set(hand.indexFinger);
            middleFinger.Set(hand.middleFinger);
            ringFinger.Set(hand.ringFinger);
            littleFinger.Set(hand.littleFinger);
        }
    }

}