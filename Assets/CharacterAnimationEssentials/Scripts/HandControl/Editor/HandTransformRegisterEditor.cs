using UnityEditor;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    [CustomEditor(typeof(HandTransformRegister))]
    public class HandTransformRegisterEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var script = target as HandTransformRegister;

            GUILayout.Space(10);

            if (GUILayout.Button("Detect"))
            {
                script.DetectHandJoints();
            }
        }
    }

}