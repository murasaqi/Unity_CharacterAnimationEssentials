using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(0.7731837f, 0.9528302f, 0.2756615f)]
[TrackClipType(typeof(AutoEyeBlinkerClip))]
[TrackBindingType(typeof(SkinnedMeshRenderer))]
public class AutoEyeBlinkerTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var mixer = ScriptPlayable<AutoEyeBlinkerMixerBehaviour>.Create (graph, inputCount);
        mixer.GetBehaviour().Clips = GetClips().ToArray();
        mixer.GetBehaviour().Director = go.GetComponent<PlayableDirector>();
        return mixer;
    }
}
