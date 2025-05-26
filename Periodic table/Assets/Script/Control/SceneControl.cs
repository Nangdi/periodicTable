using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour, ISceneControl
{
    [ReadOnly]
    public SceneControlManager.SceneObject sceneObject;


    public virtual void OnInit(SceneControlManager.SceneObject sceneObject)
    {
        this.sceneObject = sceneObject;
        Debug.Log("씬 활성화");


    }

    //비활성화
    public virtual void OnDisable() {
        if (this.gameObject.activeSelf)
        {
            Debug.Log("씬 비활성화] "+ sceneObject.objectType);
        }
    }






}
