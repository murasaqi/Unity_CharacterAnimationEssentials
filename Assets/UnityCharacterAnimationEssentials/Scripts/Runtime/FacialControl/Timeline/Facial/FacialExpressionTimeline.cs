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

        public Mesh faceMesh { get; set; }

        public SkinnedMeshRenderer face => faceSkin;

        // public float value;

        // public FacialExpressionPreset preset;
        // public FaceType faceType = FaceType.Default;
        // public bool mouthEnabled = false;

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
      

       

    }

}