using UnityEngine;
using UnityEngine.Playables;


namespace CharacterAnimationEssentials.Hand
{

    [System.Serializable]
    public class HandBehaviour : PlayableBehaviour
    {

        public HandPreset handPreset;

        [Range(0f, 1f)]
        public float strengthMultiplier = 1f;

    }

}