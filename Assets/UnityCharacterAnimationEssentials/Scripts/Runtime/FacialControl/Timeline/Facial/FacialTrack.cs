using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Linq;

namespace CharacterAnimationEssentials.Facial
{

    [TrackBindingType(typeof(FacialExpressionTimeline))]
    [TrackColor(0, 0.4f, 1)]
    [TrackClipType(typeof(FacialClip))]
    public class FacialTrack : TrackAsset
    {

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var mixer = ScriptPlayable<FacialMixerBehaviour>.Create(graph, inputCount);
            mixer.GetBehaviour().Clips = GetClips().ToArray();

            mixer.GetBehaviour().Clips.ToList().ForEach(clip =>
            {
                var clipAsset = clip.asset as FacialClip;
                var behaviour = clipAsset.behaviour;
                // foreach (var blendShape in behaviour.preset.targetBlendshapePairs)
                // {
                //      blendShape.Index = gettra .faceMesh.GetBlendShapeIndex(blendShape.Name);
                // }

               
                clip.displayName = behaviour.preset.name;
            });
            mixer.GetBehaviour().Director = go.GetComponent<PlayableDirector>();
            
            return mixer;
        }

        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            FacialExpressionTimeline trackBinding = director.GetGenericBinding(this) as FacialExpressionTimeline;
            if (trackBinding == null)
                return;
#endif
        }

    }

}