using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;



namespace CharacterAnimationEssentials.Hand
{

    [TrackBindingType(typeof(TimelineHandControl))]
    [TrackColor(0, 1, 1)]
    [TrackClipType(typeof(HandClip))]
    public class HandTrack : TrackAsset
    {

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var mixer = ScriptPlayable<HandMixerBehaviour>.Create(graph, inputCount);
            mixer.GetBehaviour().Clips = GetClips().ToArray();

            mixer.GetBehaviour().Clips.ToList().ForEach(clip =>
            {
                var clipAsset = clip.asset as HandClip;
                var behaviour = clipAsset.behaviour;
                clip.displayName = behaviour.handPreset.ToString();
            });

            mixer.GetBehaviour().Director = go.GetComponent<PlayableDirector>();
            return mixer;
        }

        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
            // Timelineから外したときに値を戻したい場合はこのように書く
#if UNITY_EDITOR
            TimelineHandControl trackBinding = director.GetGenericBinding(this) as TimelineHandControl;
            if (trackBinding == null)
                return;

            driver.AddFromName<TimelineHandControl>(trackBinding.gameObject, "handShape");
#endif
        }

    }

}
