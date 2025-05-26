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

    [Header("�����г�")]
    public DescriptionControl descriptionControl;

    [Header("�ؽ�Ʈ �̸� ����")]
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
    /// ������ �� ������ ��� ���Ǳ���
    /// </summary>
    public void SetData(ElementType elementType) {
        this.elementType = elementType;
        elementNameText.text = elementType.ToString();
    }


    //Ŭ�� �̺�Ʈ �ڵ鷯 ���� ����
    public void OnPointerClick(PointerEventData eventData)
    {
        manImg.DOFade(0, 0f);
        Debug.Log("Element PointClick..."+ elementType.ToString());
        /*if (descriptionControl)
        {
            //descriptionControl.OnInit();
        }
        else {
            Debug.Log("����� �˾�â�� ���� ���� �ʽ��ϴ�.");
        }*/
        //���ÿ� ���� ������ �̺�Ʈ �ڵ鷯
        // ����
        SoundManager.Instance.CreateSound(SoundType.btn);


    }

    private void ChoseElement() {
        switch (elementType) { 
            case GameManager.ElementType.H:
            Debug.Log("���� ����");
            break;
        }
    }

}
