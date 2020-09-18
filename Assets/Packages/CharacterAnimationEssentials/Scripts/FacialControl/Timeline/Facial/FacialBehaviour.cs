using UnityEngine;
using UnityEngine.Playables;

namespace CharacterAnimationEssentials.Facial
{

    [System.Serializable]
    public class FacialBehaviour : PlayableBehaviour
    {

        // public FaceType faceType = FaceType.Default;
        public FacialExpressionPreset preset;
        [Range(0f, 1f)]
        public float strengthMultiplier = 1f;

        public bool useMouth = false;

    }

}