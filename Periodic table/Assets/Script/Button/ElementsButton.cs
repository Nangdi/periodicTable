using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GameManager;
using static SoundManager;
using DG.Tweening;
using System.Data.Common;
using System.Buffers;

public class ElementsButton : MonoBehaviour, IPointerClickHandler
{

    public ElementType elementType;

    [Header("설명패널")]
    public DescriptionControl descriptionControl;

    [Header("텍스트 이름 정의")]
    public TMP_Text elementNameText;

    public Toggle targetToggle;

    public CanvasGroup manImg;

    public Toggle[] bundleToggle;
    public ToggleGroup toggleGroup;

    public void ValueChangeEvent(bool isOn)
    {
        if (isOn)
        {
            descriptionControl.OnInit();
            BundleOn();
            ChoseElement();
        }
        else {
            descriptionControl.OnClose();
        }

    }

    /// <summary>
    /// 에디터 용 데이터 등록 정의구간
    /// </summary>
    public void SetData(ElementType elementType) {
        this.elementType = elementType;
        elementNameText.text = elementType.ToString();
    }


    //클릭 이벤트 핸들러 설정 구간
    public void OnPointerClick(PointerEventData eventData)
    {
        manImg.DOFade(0, 0f);
        Debug.Log("Click : " + eventData.selectedObject.name);
        Debug.Log("보낼포트번호 : " + GameManager.Instance.elementNameToNumDic[eventData.selectedObject.name]);
        /*if (descriptionControl)
        {
            //descriptionControl.OnInit();
        }
        else {
            Debug.Log("연결된 팝업창이 존재 하지 않습니다.");
        }*/
        //선택에 따른 별도의 이벤트 핸들러
        // 사운드
       
        SoundManager.Instance.CreateSound(SoundType.btn);


    }

    private void ChoseElement() {
        switch (elementType) { 
            case GameManager.ElementType.H:
            //Debug.Log("꺼진 원소 : " + gameObject.name);
            break;
        }
    }
    public void BundleOn()
    {
        Debug.Log("토글번들 알파비활성화");
        if (GameManager.Instance.memorybundle != null)
        {
            for (int i = 0; i < GameManager.Instance.memorybundle.Length; i++)
            {
                if (GameManager.Instance.memorybundle[i] == targetToggle)
                {
                    continue;
                }
                GameManager.Instance.memorybundle[i].graphic.CrossFadeAlpha(0f, 0, true);
                //다른원소클릭할때 모두 꺼지기
            }
            GameManager.Instance.memorybundle = null;
        }

        if (bundleToggle.Length == 0)
        {
            Debug.Log("토글그룹 키기");

            return;
        }

        Debug.Log("토글번들 알파활성화");
        //toggleGroup.enabled = false;
        for (int i = 0; i < bundleToggle.Length; i++)
        {
            bundleToggle[i].graphic.CrossFadeAlpha(1f, 0, true);
            //다른원소클릭할때 모두 꺼지기
        }
        GameManager.Instance.memorybundle = bundleToggle;
    }
    public void test(bool dw)
    {

    }
}
