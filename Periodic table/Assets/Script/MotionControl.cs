using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionControl : MonoBehaviour
{
    public enum AnimatorNames { �ȱ�,�񵹸���,��������,�ٸ����}

    [ Header("���Ÿ�� ����")]
    public MotionType motionType;

    [System.Serializable]
    public class MotionType {
        public AnimatorNames Name;
    }


    public Animator animators;




}
