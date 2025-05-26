using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSceneControl : SceneControl
{

    //���� ��Ʈ��
    public override void OnInit(SceneControlManager.SceneObject sceneObject)
    {
        base.OnInit(sceneObject);
        //���� ��� ����
        VideoManager.Instance.VideoPlay();

    }


    public override void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {

            //���� ���� ����
            VideoManager.Instance.VideoStop();
            //Debug.Log("�� ��Ȱ��ȭ] " + sceneObject.objectType);
        }
    }

}
