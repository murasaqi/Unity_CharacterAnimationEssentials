
using UnityEngine.Timeline;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;

namespace CharacterAnimationEssentials.Facial
{

    [TrackBindingType(typeof(AutoBlink))]
    [TrackColor(0, 0.4f, 1)]
    [TrackClipType(typeof(BlinkOverrideClip))]
    public class BlinkOverrideTrack : TrackAsset
    {

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            var mixer = ScriptPlayable<BlinkOverrideMixerBehaviour>.Create(graph, inputCount);
            mixer.GetBehaviour().Clips = GetClips().ToArray();
            mixer.GetBehaviour().Director = go.GetComponent<PlayableDirector>();

            mixer.GetBehaviour().Clips.ToList().ForEach(clip =>
            {
                var clipAsset = clip.asset as BlinkOverrideClip;
                var behaviour = clipAsset.behaviour;
                clip.displayName = "Close";
            });

            return mixer;
        }

        public override void GatherProperties(PlayableDirector director, IPropertyCollector driver)
        {
#if UNITY_EDITOR
            AutoBlink trackBinding = director.GetGenericBinding(this) as AutoBlink;
            if (trackBinding == null)
                return;

            driver.AddFromName<AutoBlink>(trackBinding.gameObject, "blinkOverrider");
#endif
        }

    }

}