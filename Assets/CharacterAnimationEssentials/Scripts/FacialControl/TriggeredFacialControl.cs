using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CharacterAnimationEssentials.Facial {

    public class TriggeredFacialControl : MonoBehaviour
    {

        [SerializeField] SkinnedMeshRenderer faceSkin;

        [SerializeField] float changeTime = 0.2f;

        [SerializeField] FacialExpressionPreset defaultFace;

        public List<FacialExpressionAndKeyPair> facialExpressionAndKeyPairList;

        Mesh faceMesh;

        FacialExpressionPreset previousFace;

        float[] blendShapeValueBuffer;

        bool animating = false;

        private void Start()
        {
            faceMesh = faceSkin.sharedMesh;

            blendShapeValueBuffer = new float[faceMesh.blendShapeCount];

            previousFace = defaultFace;
        }

        private void OnValidate()
        {
            facialExpressionAndKeyPairList.ForEach(pair =>
            {
                if (pair.facialExpressionPreset)
                {
                    pair.name = pair.facialExpressionPreset.name;
                }
            });

            faceMesh = faceSkin.sharedMesh;

            ResolveAllBlendShapeIndexes();
        }



        private void Update()
        {

            facialExpressionAndKeyPairList.ForEach(pair =>
            {

                if (Input.GetKeyDown(pair.keyCode))
                {
                    Trigger(pair.facialExpressionPreset);
                }

            });


            ApplyToSkin();

        }

        

        void ApplyToSkin()
        {
            for (int i = 0; i < blendShapeValueBuffer.Length; i++)
            {
                SetBlendshapeWeightAt(i, Mathf.Max(0, Mathf.Min(100f, blendShapeValueBuffer[i])));
            }
        }


        private void Trigger(FacialExpressionPreset face)
        {
            if (animating) return;

            StartCoroutine(ChangeFaceTo(face));

        }




        IEnumerator ChangeFaceTo(FacialExpressionPreset currentFace)
        {

            animating = true;

            float t = 0;


            while(t < changeTime)
            {

                float fraction = t / changeTime;
                
                Zero();

                // Previous
                float weight = 1 - fraction;
                previousFace.targetBlendshapePairs.ForEach(blendShapeIndexPair =>
                {
                    blendShapeValueBuffer[blendShapeIndexPair.Index] += blendShapeIndexPair.MaxValue * weight;
                });

                // Current
                weight = fraction;
                currentFace.targetBlendshapePairs.ForEach(blendShapeIndexPair =>
                {
                    blendShapeValueBuffer[blendShapeIndexPair.Index] += blendShapeIndexPair.MaxValue * weight;
                });

                t += Time.deltaTime;

                yield return null;
            }

            animating = false;

            previousFace = currentFace;
        }


        

        void Zero()
        {
            for (int i = 0; i < blendShapeValueBuffer.Length; i++)
            {
                blendShapeValueBuffer[i] = 0;
            }
        }

        public void SetBlendshapeWeightAt(int index, float value)
        {
            if (faceSkin)
                faceSkin.SetBlendShapeWeight(index, value);
        }


        void ResolveAllBlendShapeIndexes()
        {
            if (!faceMesh)
            {
                return;
            }

            facialExpressionAndKeyPairList.ForEach(pair =>
            {

                pair.facialExpressionPreset.targetBlendshapePairs.ForEach(target =>
                {

                    var index = faceMesh.GetBlendShapeIndex(target.Name);

                    if (index == -1)
                    {
                        target.Index = 0;   // for use error detection

                        Debug.LogError($"{pair.facialExpressionPreset.name} : {target.Name} is not found");
                    }

                    target.Index = index;
                });

            });
        }
    }

    [System.Serializable]
    public class FacialExpressionAndKeyPair
    {
        [HideInInspector]
        public string name;

        public FacialExpressionPreset facialExpressionPreset;
        public KeyCode keyCode;
    }

}