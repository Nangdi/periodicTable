using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GameManager;
using static SoundManager;
using DG.Tweening;

public class ElementsButton : MonoBehaviour, IPointerClickHandler
{

    public ElementType elementType;

    [Header("설명패널")]
    public DescriptionControl descriptionControl;

    [Header("텍스트 이름 정의")]
    public TMP_Text elementNameText;

    public Toggle targetToggle;

    public CanvasGroup manImg;


    public void ValueChangeEvent(bool isOn)
    {
        if (isOn)
        {
            descriptionControl.OnInit();
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
        Debug.Log("Element PointClick..."+ elementType.ToString());
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
            Debug.Log("수소 선택");
            break;
        }
    }

}
