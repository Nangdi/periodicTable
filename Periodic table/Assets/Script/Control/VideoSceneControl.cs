using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoSceneControl : SceneControl
{

    //시작 컨트롤
    public override void OnInit(SceneControlManager.SceneObject sceneObject)
    {
        base.OnInit(sceneObject);
        //영상 재생 진행
        VideoManager.Instance.VideoPlay();

    }


    public override void OnDisable()
    {
        if (this.gameObject.activeSelf)
        {

            //영상 종료 진행
            VideoManager.Instance.VideoStop();
            //Debug.Log("씬 비활성화] " + sceneObject.objectType);
        }
    }

}
