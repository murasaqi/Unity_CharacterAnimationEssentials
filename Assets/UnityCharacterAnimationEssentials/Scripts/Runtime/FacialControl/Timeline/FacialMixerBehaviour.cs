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
        public PlayableDirector Director { get; set; }
        private FacialExpressionTimeline binding;

       

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {

            binding = playerData as FacialExpressionTimeline;

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

            var time = Director.time;

            float value = 0f;
            var isOnClip = false;
            for (int i = 0; i < Clips.Length; i++)
            {

                var clip = Clips[i];
                var clipAsset = clip.asset as FacialClip;
                var behaviour = clipAsset.behaviour;
                var clipWeight = playable.GetInputWeight(i);
                var clipProgress = Mathf.Clamp((float)((time - clip.start) / clip.duration),0f,1f);

                // if inside of clip
                if (clip.start<Director.time && Director.time <= clip.end) 
                {
                
                    if(clipProgress < behaviour.easeInOutLength)
                    {
                        var normalized = clipProgress / behaviour.easeInOutLength;
                        value = QuadraticEaseInOut(normalized, 0f, 1f, 1f) * clipWeight;
                    }
                    else if(clipProgress >= 1 - behaviour.easeInOutLength)
                    {
                        var normalized = (clipProgress - (1 - behaviour.easeInOutLength)) / behaviour.easeInOutLength;
                        value = QuadraticEaseInOut(1 - normalized, 0f, 1f, 1f) * clipWeight;
                    }
                    else
                    {
                        value = 1f * clipWeight;
                    }

                    behaviour.preset.value = value;
                    UpdateFacial(behaviour);
                    isOnClip = true;
                    
                }
                // if (Director.time > clip.end && behaviour.preset.value != 0f ||
                //     Director.time < clip.start && behaviour.preset.value != 0f )
                // {
                //     behaviour.preset.value = 0f;
                //     UpdateFacial(behaviour);
                // }
                
            }


            if (!isOnClip)
            {
                // ResetFace();
            }
            // binding.faceType = faceType;
            // binding.value = value;   -=
            
            
            
            // binding.mouthEnabled = mouthEnabled;
        }

        public void ResetFace()
        {
            if (binding != null)
            {
                for (int i = 0; i < binding.BlendshapeNum; i++)
                {
                    binding.face.SetBlendShapeWeight(i, 0);
                }   
            }
        }
        public void UpdateFacial(FacialBehaviour behaviour)
        {
            var preset = behaviour.preset;
            
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
            var count = 0;

            foreach (var blendShape in  preset.targetBlendshapePairs)
            {

                blendShape.Index = binding.faceMesh.GetBlendShapeIndex(blendShape.Name);
                
                
                if (blendShape.isMouth)
                {
                    if (behaviour.useMouth)
                    {
                        binding.face.SetBlendShapeWeight(blendShape.Index, blendShape.MaxValue * preset.value);
                    }
                    else
                    {
                        // binding.face.SetBlendShapeWeight(blendShape.Index, 0f);
                    }
                }
                else
                {
                    binding.face.SetBlendShapeWeight(blendShape.Index, blendShape.MaxValue * preset.value);

                }

                count++;
            }
        }
        

        
        float QuadraticEaseInOut(float time, float startValue, float change, float duration)
        {
            time /= duration / 2;
            if (time < 1)
            {
                return change / 2 * time * time + startValue;
            }

            time--;
            return -change / 2 * (time * (time - 2) - 1) + startValue;
        }
    }

}