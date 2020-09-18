using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterAnimationEssentials.Facial
{

    public class FacialMixerBehaviour : PlayableBehaviour
    {

        float[] blendshapeValues;
        int prevBlendshapeNum = 0;

        public TimelineClip[] Clips { get; set; }


        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {

            var binding = playerData as FacialExpressionTimeline;

            if (!binding || binding.BlendshapeNum == -1)
            {
                return;
            }

            // recreate blendshape value array when the number of blendshape is changed.
            if (prevBlendshapeNum != binding.BlendshapeNum)
            {
                blendshapeValues = new float[binding.BlendshapeNum];
                prevBlendshapeNum = binding.BlendshapeNum;
            }


            // initialize blendshapes
            for (int i = 0; i < binding.BlendshapeNum; i++)
            {
                blendshapeValues[i] = 0;
            }


            // sum all clips
            for (int i = 0; i < Clips.Length; i++)
            {

                var clip = Clips[i];
                var clipAsset = clip.asset as FacialClip;
                var behaviour = clipAsset.behaviour;
                var clipWeight = playable.GetInputWeight(i);

                var facialExpression = behaviour.preset;
                if (!facialExpression) continue;

                foreach (var pair in facialExpression.targetBlendshapePairs)
                {
                    blendshapeValues[pair.Index] += pair.MaxValue * behaviour.strengthMultiplier * clipWeight;
                }

            }

            // set to face mesh
            for (int i = 0; i < binding.BlendshapeNum; i++)
            {
                binding.SetBlendshapeWeightAt(i, blendshapeValues[i]);
            }
        }
    }

}