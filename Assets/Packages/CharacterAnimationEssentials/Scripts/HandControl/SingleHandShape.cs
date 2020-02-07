using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    [System.Serializable]
    public class SingleHandShape
    {

        public string handName;

        public Finger thumb;
        public Finger indexFinger;
        public Finger middleFinger;
        public Finger ringFinger;
        public Finger littleFinger;

        public SingleHandShape()
        {
            thumb = new Finger();
            indexFinger = new Finger();
            middleFinger = new Finger();
            ringFinger = new Finger(); ;
            littleFinger = new Finger();
        }

        public static SingleHandShape operator *(SingleHandShape hand, float weight)
        {
            SingleHandShape result = new SingleHandShape();
            result.thumb = hand.thumb * weight;
            result.indexFinger = hand.indexFinger * weight;
            result.middleFinger = hand.middleFinger * weight;
            result.ringFinger = hand.ringFinger * weight;
            result.littleFinger = hand.littleFinger * weight;
            return result;
        }

        public static SingleHandShape operator +(SingleHandShape hand1, SingleHandShape hand2)
        {
            SingleHandShape result = new SingleHandShape();
            result.thumb = hand1.thumb + hand2.thumb;
            result.indexFinger = hand1.indexFinger + hand2.indexFinger;
            result.middleFinger = hand1.middleFinger + hand2.middleFinger;
            result.ringFinger = hand1.ringFinger + hand2.ringFinger;
            result.littleFinger = hand1.littleFinger + hand2.littleFinger;
            return result;
        }


    }

}