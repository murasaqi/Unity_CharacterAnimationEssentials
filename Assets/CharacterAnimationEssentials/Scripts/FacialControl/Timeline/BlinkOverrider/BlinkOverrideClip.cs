using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterAnimationEssentials.Facial
{
    public class BlinkOverrideClip : PlayableAsset, ITimelineClipAsset
    {

        public BlinkOverrideBehaviour behaviour = new BlinkOverrideBehaviour();

        public ClipCaps clipCaps {
            get {
                return ClipCaps.Blending;
            }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<BlinkOverrideBehaviour>.Create(graph);
        }

    }

}