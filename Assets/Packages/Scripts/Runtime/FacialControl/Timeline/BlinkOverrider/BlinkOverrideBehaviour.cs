using UnityEngine;
using UnityEngine.Playables;

namespace CharacterAnimationEssentials.Facial
{


    [System.Serializable]
    public class BlinkOverrideBehaviour : PlayableBehaviour
    {

        [Range(0f, 0.5f)]
        public float easeInOutLength = 0.2f;

    }

}