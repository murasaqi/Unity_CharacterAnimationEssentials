using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


namespace CharacterAnimationEssentials.Hand
{
    public class HandClip : PlayableAsset, ITimelineClipAsset
    {

        public HandBehaviour behaviour = new HandBehaviour();

        public ClipCaps clipCaps {
            get {
                return ClipCaps.Blending;
            }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            return ScriptPlayable<HandBehaviour>.Create(graph);
        }

    }

}