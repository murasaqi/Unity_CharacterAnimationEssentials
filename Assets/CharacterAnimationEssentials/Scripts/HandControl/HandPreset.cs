using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace CharacterAnimationEssentials.Hand
{

    [CreateAssetMenu(menuName = "ProjectBLUE/Create Hand Shape Preset")]
    public class HandPreset : ScriptableObject
    {
        public SingleHandShape handShape;

    }

}