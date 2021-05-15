using System;
using CharacterAnimationEssentials.Facial;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class AutoEyeBlinkerMixerBehaviour : PlayableBehaviour
{
    public TimelineClip[] Clips { get; set; }
    public PlayableDirector Director { get; set; }

    private SkinnedMeshRenderer blendShapeMesh;
    // private FacialExpressionTimeline binding;
    // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        blendShapeMesh = playerData as SkinnedMeshRenderer;

        if (!blendShapeMesh)
            return;

        // int inputCount = playable.GetInputCount ();

        for (int i = 0; i < Clips.Length; i++)
        {
            var clip = Clips[i];
            float inputWeight = playable.GetInputWeight(i);
            ScriptPlayable<AutoEyeBlinkerBehaviour> inputPlayable = (ScriptPlayable<AutoEyeBlinkerBehaviour>)playable.GetInput(i);
            AutoEyeBlinkerBehaviour input = inputPlayable.GetBehaviour ();
            
           

            if (clip.start <= Director.time && Director.time <= clip.end)
            {
                var startTime = clip.start + input.nextStartTime;
                var endTime = startTime + input.blinkDuration;
                if (Director.time >endTime)
                {
                    input.nextStartTime = Mathf.Clamp(input.nextStartTime+Random.Range(input.randomOpenDurationMin, input.randomOpenDurationMax),0f,(float)clip.duration - input.blinkDuration);
                    // if(input.nextStartTime > clip.end - input.blinkDuration)
                }
                var clipProgress = Mathf.Clamp(((float)(Director.time - startTime) / input.blinkDuration),0f, 1f  );

                input.progress = clipProgress;
                
                if (Director.time > endTime && input.progress < 1f) input.progress = 1f;
                
                UpdateFacial(input.preset, input.easing.Evaluate(input.progress));
                Debug.Log($"time: {Director.time}, next: {startTime},progress: {clipProgress}, end:{endTime}");
                
            }

            if (clip.end < Director.time && input.progress != 1)
            {
                input.progress = 1f;    
                UpdateFacial(input.preset, input.easing.Evaluate(input.progress));
            }
            if(Director.time < clip.start)
            {
                input.nextStartTime = 0f;
                if (input.progress != 0f)
                {
                    UpdateFacial(input.preset, input.easing.Evaluate(0f));
                }
                input.progress = 0f;
                
            }
            
           
            
        }
    }
    
    public void UpdateFacial(FacialExpressionPreset preset, float progress)
    {
        // var preset = behaviour.preset;
            
        int faceBlendshapeNum = blendShapeMesh.sharedMesh.blendShapeCount;
       

        foreach (var blendShape in  preset.targetBlendshapePairs)
        {

            blendShape.Index = blendShapeMesh.sharedMesh.GetBlendShapeIndex(blendShape.Name);
            
            blendShapeMesh.SetBlendShapeWeight(blendShape.Index, blendShape.MaxValue * progress);
            
        }
    }
}
