using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterAnimationEssentials.Hand
{

    public class TimelineRightHandControl : TimelineHandControl
    {

        private void LateUpdate()
        {


            if (handTransformRegister == null)
            {
                return;
            }

            handTransformRegister.rightHandTransform.Set(handShape);
        }

    }
}