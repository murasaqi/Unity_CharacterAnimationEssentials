
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterAnimationEssentials.Hand
{

    [ExecuteInEditMode]
    public class TimelineHandControl : MonoBehaviour
    {

        public HandTransformRegister handTransformRegister;

        [HideInInspector]
        public SingleHandShape handShape;

    }

}