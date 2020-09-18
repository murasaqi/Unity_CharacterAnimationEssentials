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

        [SerializeField] List<FacialExpressionPreset> facialExpressionList;


        Dictionary<FaceType, FacialExpressionPreset> facialExpressionDict = new Dictionary<FaceType, FacialExpressionPreset>();

        Mesh faceMesh;

        public int BlendshapeNum {
            get {
                return faceMesh ? faceMesh.blendShapeCount : -1;
            }
        }

        void Start()
        {
            faceMesh = faceSkin.sharedMesh;

            ConvertListToDict();

            ResolveAllBlendShapeIndexes();
        }


        private void OnValidate()
        {
            Start();
        }


        public void SetBlendshapeWeightAt(int index, float value)
        {
            if (faceSkin)
                faceSkin.SetBlendShapeWeight(index, value);
        }



        // public FacialExpressionPreset GetFacialExpression()
        // {
        //
        //     try
        //     {
        //         return facialExpressionDict[faceType];
        //     }
        //     catch (Exception e)
        //     {
        //         Debug.LogWarning($"There is no such face type : {faceType} or {e.ToString()}");
        //         return null;
        //     }
        //
        // }

        void ConvertListToDict()
        {
            facialExpressionDict.Clear();

            facialExpressionList.ForEach(facialExpression =>
            {
                try
                {
                    facialExpressionDict.Add(facialExpression.faceType, facialExpression);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Check if there is same face type in the list : {facialExpression.faceType}. or {e.ToString()}");
                }

            });
        }

        // Calculate each blendshape index inside of facial expression scriptable object
        void ResolveAllBlendShapeIndexes()
        {
            facialExpressionList.ForEach(facialExpression =>
            {


                facialExpression.targetBlendshapePairs.ForEach(target =>
                {

                    var index = faceMesh.GetBlendShapeIndex(target.Name);

                    if (index == -1)
                    {
                        target.Index = 0;   // for use error detection

                        Debug.LogError($"{facialExpression.name} : {target.Name} is not found");
                    }

                    target.Index = index;
                });

            });
        }

    }

}