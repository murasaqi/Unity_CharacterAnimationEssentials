using System;
using CharacterAnimationEssentials.Facial;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class AutoEyeBlinkerBehaviour : PlayableBehaviour
{

    public FacialExpressionPreset preset;
    public float blinkDuration = 0.3f;
    public float randomOpenDurationMin = 1;
    public float randomOpenDurationMax = 4;
    [HideInInspector]public float nextStartTime = 0;
    [HideInInspector]public float progress =0f;
    // public float interval = 0f;
    public AnimationCurve easing;
}
