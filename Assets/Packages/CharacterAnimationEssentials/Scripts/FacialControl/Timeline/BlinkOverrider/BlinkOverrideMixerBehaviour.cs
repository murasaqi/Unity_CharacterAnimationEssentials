using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterAnimationEssentials.Facial
{

    public class BlinkOverrideMixerBehaviour : PlayableBehaviour
    {

        public TimelineClip[] Clips { get; set; }

        public PlayableDirector Director { get; set; }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {

            var binding = playerData as AutoBlink;

            var time = Director.time;


            if (!binding)
            {
                return;
            }

            float value = 0;

            // sum all clips
            for (int i = 0; i < Clips.Length; i++)
            {
                var clip = Clips[i];
                var clipAsset = clip.asset as BlinkOverrideClip;
                var behaviour = clipAsset.behaviour;
                var clipWeight = playable.GetInputWeight(i);

                var clipProgress = (float)((time - clip.start) / clip.duration);

                if (clipProgress < behaviour.easeInOutLength)
                {
                    var normalized = clipProgress / behaviour.easeInOutLength;
                    value = QuadraticEaseInOut(normalized, 0f, 1f, 1f) * clipWeight;
                }
                else if (clipProgress >= 1 - behaviour.easeInOutLength)
                {
                    var normalized = (clipProgress - (1 - behaviour.easeInOutLength)) / behaviour.easeInOutLength;
                    value = QuadraticEaseInOut(1 - normalized, 0f, 1f, 1f) * clipWeight;
                }
                else
                {
                    value = 1f * clipWeight;
                }

            }

            binding.blinkOverrider = value * 100;
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