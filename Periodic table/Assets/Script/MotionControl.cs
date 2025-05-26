using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour
{
    public enum AnimatorNames { 걷기,목돌리기,꼬리흔들기,다리들기}

    [ Header("모션타입 정의")]
    public MotionType motionType;

    [System.Serializable]
    public class MotionType {
        public AnimatorNames Name;
    }


    public Animator animators;




}
