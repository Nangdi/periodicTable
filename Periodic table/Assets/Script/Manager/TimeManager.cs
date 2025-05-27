using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static SceneControlManager;
using static TimeManager;

//타임 카운터 설정 구간
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

    //시작 커맨드
    private Coroutine onLoop = null;
    [Header("타임 카운터(초 기준)")]
    public int maxTimeCount = 10;
    
    //[ReadOnly]
    [SerializeField]
    private int currentCount = 0;

    //타임카운터 변경이벤트 핸들러
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


    //시작 커맨드
    private void OnInitStart() {
        OnRemoveInit();
        onLoop = StartCoroutine(OnLoop());
        //SceneControlManager.Instance.OnLoadScene(SceneType.MainScene);
    }


    /// <summary>
    /// 루프 작동 시작 구간 
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
                Debug.Log("초기화면으로 이동");
               /* GameManager.Instance.timelineSceneController.isTimePlay = false;
                GameManager.Instance.timelineSceneController.TimelineStop(0);
                GameManager.Instance.timelineSceneController.GotoTimeClip(
                    TimelineSceneController.SceneMode.MainScene, 
                    TimelineSceneController.SceneIndex.index_0);

                VideoPlayerManager.Instance.OnVideoLoad(VideoPlayerManager.Type.인트로);
                SceneControlManager.Instance.OnLoadScene(SceneType.MainScene);*/
                //GameManager.Instance.OnReset();
                //MainGameManager.Instance.NextGoToScene(MainGameManager.Instance.resetSceneMode);
                currentCount = 0;
            }
        }
    }

    //포인트 다운
    public void OnPointDownEvent() {
        Debug.Log("포인트 다운 이벤트 핸들러");
    }

    //포인트 업
    public void OnPointUpEvent() {
        Debug.Log("포인트 업 이벤트 핸들러");
    }


    /// <summary>
    /// 입력키 및 씬 이동시 현재 카운터 정보 초기화
    /// </summary>
    public void CurrentCountReset() {
        currentCount = 0;
    }

    //리턴 씬 유형
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
            Debug.Log("마우스 다운");
            currentCount = 0;
        }
    }


}
