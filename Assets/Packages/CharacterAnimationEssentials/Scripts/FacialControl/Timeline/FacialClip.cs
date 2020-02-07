using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterAnimationEssentials.Facial
{
    public class FacialClip : PlayableAsset, ITimelineClipAsset
    {

        public FacialBehaviour behaviour = new FacialBehaviour();

        public ClipCaps clipCaps {
            get {
                return ClipCaps.Blending;
            }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<FacialBehaviour>.Create(graph);
        }

    }

}