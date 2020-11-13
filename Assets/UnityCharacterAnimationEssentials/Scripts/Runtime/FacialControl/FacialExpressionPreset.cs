﻿using System.Collections.Generic;
using UnityEngine;


namespace CharacterAnimationEssentials.Facial
{

    [CreateAssetMenu(menuName = "ProjectBLUE/Create Facial Expression Preset")]
    public class FacialExpressionPreset : ScriptableObject
    {

        public FaceType faceType = FaceType.Default;

        public string facialName;

        public List<BlendshapeNameIndexMaxValuePair> targetBlendshapePairs;

    }

}