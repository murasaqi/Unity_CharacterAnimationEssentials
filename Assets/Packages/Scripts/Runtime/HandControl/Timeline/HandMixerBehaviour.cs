using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


namespace CharacterAnimationEssentials.Hand
{
    public class HandMixerBehaviour : PlayableBehaviour
    {

        public TimelineClip[] Clips { get; set; }
        public PlayableDirector Director { get; set; }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {

            // TODO
            var binding = playerData as TimelineHandControl;
            if (!binding)
            {
                return;
            }

            var time = Director.time;


            SingleHandShape handShape = new SingleHandShape();

            for (int i = 0; i < Clips.Length; i++)
            {

                var clip = Clips[i];
                var clipAsset = clip.asset as HandClip;
                var behaviour = clipAsset.behaviour;
                var clipWeight = playable.GetInputWeight(i);
                var clipProgress = (float)((time - clip.start) / clip.duration);

                // if inside of clip
                if (0f <= clipProgress && clipProgress <= 1f)
                {

                    handShape += behaviour.handPreset.handShape * behaviour.strengthMultiplier * clipWeight;

                }

            }

            binding.handShape = handShape;
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