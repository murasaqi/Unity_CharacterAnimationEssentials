using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    [System.Serializable]
    public class HandShape
    {
        public float Weight { get; set; }

        public SingleHandShape leftHand;
        public SingleHandShape rightHand;

        public static HandShape operator *(HandShape hand, float weight)
        {
            HandShape result = new HandShape();
            result.leftHand = hand.leftHand * weight;
            result.rightHand = hand.rightHand * weight;
            return result;
        }

        public static HandShape operator +(HandShape hand1, HandShape hand2)
        {
            HandShape result = new HandShape();
            result.leftHand = hand1.leftHand + hand2.leftHand;
            result.rightHand = hand1.rightHand + hand2.rightHand;
            return result;
        }

    }
}
