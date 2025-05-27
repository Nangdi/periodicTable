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

    [Header("�����г�")]
    public DescriptionControl descriptionControl;

    [Header("�ؽ�Ʈ �̸� ����")]
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
        Debug.Log("Click : " + eventData.selectedObject.name);
        Debug.Log("������Ʈ��ȣ : " + GameManager.Instance.elementNameToNumDic[eventData.selectedObject.name]);
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
            //Debug.Log("���� ���� : " + gameObject.name);
            break;
        }
    }
    public void BundleOn()
    {
        Debug.Log("��۹��� ���ĺ�Ȱ��ȭ");
        if (GameManager.Instance.memorybundle != null)
        {
            for (int i = 0; i < GameManager.Instance.memorybundle.Length; i++)
            {
                if (GameManager.Instance.memorybundle[i] == targetToggle)
                {
                    continue;
                }
                GameManager.Instance.memorybundle[i].graphic.CrossFadeAlpha(0f, 0, true);
                //�ٸ�����Ŭ���Ҷ� ��� ������
            }
            GameManager.Instance.memorybundle = null;
        }

        if (bundleToggle.Length == 0)
        {
            Debug.Log("��۱׷� Ű��");

            return;
        }

        Debug.Log("��۹��� ����Ȱ��ȭ");
        //toggleGroup.enabled = false;
        for (int i = 0; i < bundleToggle.Length; i++)
        {
            bundleToggle[i].graphic.CrossFadeAlpha(1f, 0, true);
            //�ٸ�����Ŭ���Ҷ� ��� ������
        }
        GameManager.Instance.memorybundle = bundleToggle;
    }
    public void test(bool dw)
    {

    }
}
