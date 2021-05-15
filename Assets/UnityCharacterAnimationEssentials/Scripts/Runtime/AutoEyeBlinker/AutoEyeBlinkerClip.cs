using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class AutoEyeBlinkerClip : PlayableAsset, ITimelineClipAsset
{
    public AutoEyeBlinkerBehaviour template = new AutoEyeBlinkerBehaviour ();

    public ClipCaps clipCaps
    {
        get { return ClipCaps.All; }
    }

    public override Playable CreatePlayable (PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<AutoEyeBlinkerBehaviour>.Create (graph, template);
        AutoEyeBlinkerBehaviour clone = playable.GetBehaviour ();
        return playable;
    }
}
