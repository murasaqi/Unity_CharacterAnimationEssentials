using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CharacterAnimationEssentials.Hand
{

    public class TimelineLeftHandControl : TimelineHandControl
    {
        private void LateUpdate()
        {

            if (handTransformRegister == null)
            {
                return;
            }

            handTransformRegister.leftHandTransform.Set(handShape);

        }
    }

}