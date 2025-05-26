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
        Debug.Log("�� Ȱ��ȭ");


    }

    //��Ȱ��ȭ
    public virtual void OnDisable() {
        if (this.gameObject.activeSelf)
        {
            Debug.Log("�� ��Ȱ��ȭ] "+ sceneObject.objectType);
        }
    }






}
