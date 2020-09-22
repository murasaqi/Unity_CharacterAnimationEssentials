using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Facial
{

    [ExecuteInEditMode]
    public class FacialExpressionTimeline : MonoBehaviour
    {

        [SerializeField] SkinnedMeshRenderer faceSkin;

        // [SerializeField] List<FacialExpressionPreset> facialExpressionList;


        // Dictionary<string, FacialExpressionPreset> facialExpressionDict = new Dictionary<string, FacialExpressionPreset>();

        Mesh faceMesh;

        public int BlendshapeNum {
            get {
                return faceMesh ? faceMesh.blendShapeCount : -1;
            }
        }

        void Start()
        {
            faceMesh = faceSkin.sharedMesh;

            // ConvertListToDict();

            // ResolveAllBlendShapeIndexes();
        }


        private void OnValidate()
        {
            Start();
        }

        public int GetIndexByName(string targetName)
        {
            return faceMesh.GetBlendShapeIndex(targetName);
        }

        public void SetBlendshapeWeightAt(int index, float value)
        {
            Debug.Log($"{index},{value}");
            // var index = faceMesh.GetBlendShapeIndex(targetName);
            if (faceSkin)
                faceSkin.SetBlendShapeWeight(index, value);
        }


    }

}