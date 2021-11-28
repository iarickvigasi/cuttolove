using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnIntroductionAnimationEnd : MonoBehaviour
{
    public void AnimationEnd()
    {
        SceneManager.Instance.uiAnimationsController.OnIntroductionEnd();
    }
}
