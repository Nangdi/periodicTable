using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static SceneControlManager;
using static TimeManager;

//Ÿ�� ī���� ���� ����
public class TimeManager : MonoBehaviour
{

    private static TimeManager instance = null;

    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance= GameObject.FindObjectOfType<TimeManager>();
            }
            return instance;
        }
    }

    //���� Ŀ�ǵ�
    private Coroutine onLoop = null;
    [Header("Ÿ�� ī����(�� ����)")]
    public int maxTimeCount = 10;
    
    //[ReadOnly]
    [SerializeField]
    private int currentCount = 0;

    //Ÿ��ī���� �����̺�Ʈ �ڵ鷯
    [Serializable]
    public class TimeCountChangeEvent : UnityEvent<int,int> { }

    public TimeCountChangeEvent timeCountChangeEvent;


    public void OnEnable()
    {
        OnInitStart();
    }

    private void OnDisable()
    {
        OnRemoveInit();
    }

    private void OnRemoveInit()
    {
        if (onLoop != null) { 
            StopCoroutine(onLoop);
            onLoop = null;
        }
    }


    //���� Ŀ�ǵ�
    private void OnInitStart() {
        OnRemoveInit();
        onLoop = StartCoroutine(OnLoop());
        //SceneControlManager.Instance.OnLoadScene(SceneType.MainScene);
    }


    /// <summary>
    /// ���� �۵� ���� ���� 
    /// </summary>
    /// <returns></returns>
    IEnumerator OnLoop() {
        yield return null;
        Debug.Log("[OnInit]");
        while (true) {
            yield return new WaitForSeconds(1f);
            yield return new WaitUntil(()=> IsSceneMode());
            if (currentCount < maxTimeCount) {
                timeCountChangeEvent.Invoke(currentCount, maxTimeCount);
                ++currentCount;
            }else{
                timeCountChangeEvent.Invoke(currentCount, maxTimeCount);
                SceneControlManager.Instance.OnLoadScene(SceneType.MainScene);
                Debug.Log("�ʱ�ȭ������ �̵�");
               /* GameManager.Instance.timelineSceneController.isTimePlay = false;
                GameManager.Instance.timelineSceneController.TimelineStop(0);
                GameManager.Instance.timelineSceneController.GotoTimeClip(
                    TimelineSceneController.SceneMode.MainScene, 
                    TimelineSceneController.SceneIndex.index_0);

                VideoPlayerManager.Instance.OnVideoLoad(VideoPlayerManager.Type.��Ʈ��);
                SceneControlManager.Instance.OnLoadScene(SceneType.MainScene);*/
                //GameManager.Instance.OnReset();
                //MainGameManager.Instance.NextGoToScene(MainGameManager.Instance.resetSceneMode);
                currentCount = 0;
            }
        }
    }

    //����Ʈ �ٿ�
    public void OnPointDownEvent() {
        Debug.Log("����Ʈ �ٿ� �̺�Ʈ �ڵ鷯");
    }

    //����Ʈ ��
    public void OnPointUpEvent() {
        Debug.Log("����Ʈ �� �̺�Ʈ �ڵ鷯");
    }


    /// <summary>
    /// �Է�Ű �� �� �̵��� ���� ī���� ���� �ʱ�ȭ
    /// </summary>
    public void CurrentCountReset() {
        currentCount = 0;
    }

    //���� �� ����
    private bool IsSceneMode() {
        bool result = false;
        switch (SceneControlManager.Instance.currentObjectType) {
            case SceneControlManager.SceneType.StandbyVideo:
            /*case SceneControlManager.SceneType.MainScene:*/
                result = false;
                currentCount = 0;
                break;
            default:
                result = true;
                break;

        }

        return result;
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("���콺 �ٿ�");
            currentCount = 0;
        }
    }


}
