using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static SceneControlManager;

/// <summary>
/// 씬 컨트롤 매니저
/// </summary>
public class SceneControlManager : MonoBehaviour
{
    private static SceneControlManager instance;

    public static SceneControlManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<SceneControlManager>();
            }
            return instance;
        }
    }
    public bool isMouseCursor = true;

    public List<SceneObject> sceneObjectList;
    public enum SceneType {
        StandbyVideo,
        MainScene,
        Scene1, 
        Scene2,
        Scene3, 
        Scene4, 
        Scene5, 
        Scene6, 
        Scene7, 
        Scene8,
        Scene11, 
        Scene12, 
        Scene13, 
        Scene14, 
        Scene15, 
        Scene16
    }

    [System.Serializable]
    public class SceneObject
    {

        public SceneType objectType;
        public CanvasGroup canvasGroup;
        //씬 컨트롤
        public SceneControl sceneControl;

    }
    public SceneType currentObjectType = SceneType.MainScene;
    private void OnEnable()
    {
        UnityEngine.Cursor.visible = isMouseCursor;

        OnInit();
    }

    public void OnInit() {
        SceneReset(currentObjectType);
    }
    private void SceneReset(SceneType choseobjectType)
    {
        SceneObject[] _sceneObjectList =
               Array.FindAll(sceneObjectList.ToArray(), item => !item.objectType.Equals(choseobjectType));
        for (int i = 0; i < _sceneObjectList.Length; i++)
        {
            SceneObject sceneObject = _sceneObjectList[i];
            sceneObject.canvasGroup.interactable = false;
            sceneObject.canvasGroup.blocksRaycasts = false;
            DOTween.To(() => sceneObject.canvasGroup.alpha,
                      alpha => sceneObject.canvasGroup.alpha = alpha,
                      0, 0.2f).OnComplete(() => OnDisableSceneObject(sceneObject));//.OnComplete(=>OnDisableSceneObject(sceneObject));
        }
        SceneObject _sceneObject= Array.Find(sceneObjectList.ToArray(), item => item.objectType.Equals(choseobjectType));
        if (_sceneObject!=null) {
            _sceneObject.canvasGroup.interactable = true;
            _sceneObject.canvasGroup.blocksRaycasts = true;
            _sceneObject.canvasGroup.alpha = 1;
        }
    }

    public void OnLoadScene(SceneType objectType)
    {
        if (objectType.Equals(SceneType.MainScene))
        {
            
            //videoPlayerControl.OnVideoReset();
        }
        if (!currentObjectType.Equals(objectType))
        {

            SceneObject[] _sceneObjectList =
                Array.FindAll(sceneObjectList.ToArray(), item => !item.objectType.Equals(objectType));
            for (int i = 0; i < _sceneObjectList.Length; i++)
            {
                SceneObject sceneObject = _sceneObjectList[i];
                sceneObject.canvasGroup.interactable = false;
                sceneObject.canvasGroup.blocksRaycasts = false;
                DOTween.To(() => sceneObject.canvasGroup.alpha,
                          alpha => sceneObject.canvasGroup.alpha = alpha,
                          0, 0.2f).OnComplete(() => OnDisableSceneObject(sceneObject));//.OnComplete(=>OnDisableSceneObject(sceneObject));
                sceneObject.sceneControl.OnDisable();
            }


            int index = Array.FindIndex(sceneObjectList.ToArray(), item => item.objectType.Equals(objectType));

            if (index > -1)
            {
                SceneObject sceneObject = sceneObjectList[index];
                sceneObject.sceneControl.gameObject.SetActive(true);

                currentObjectType = sceneObject.objectType;

                DOTween.To(() => sceneObject.canvasGroup.alpha,
                      alpha => sceneObject.canvasGroup.alpha = alpha,
                      1f, 0.2f).OnComplete(OnLoadCompleteMotion);

                sceneObject.sceneControl.OnInit(sceneObject);
                // SoundManager.Instance.CreateSound(SoundType.select);
            }
        }
    }


    private void OnDisableSceneObject(SceneObject sceneObject)
    {
       
        sceneObject.sceneControl.gameObject.SetActive(false);
    }


    private void OnLoadCompleteMotion()
    {
        SceneObject sceneObject = Array.Find(sceneObjectList.ToArray(), item => item.objectType.Equals(currentObjectType));
        sceneObject.canvasGroup.interactable = true;
        sceneObject.canvasGroup.blocksRaycasts = true;
       


    }
}
