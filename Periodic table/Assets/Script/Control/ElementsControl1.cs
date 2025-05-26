using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementsControl1 : MonoBehaviour
{
    //���� ������ ���� 
    public ElementsButton elementsPrefab;


    //���� ������ ����

    public ToggleGroup toggleGroup;


    [Header("���� ���� ��� ���� ����")]
    public DescriptionData descriptionData;

    [System.Serializable]
    public class DescriptionData { 
        //�� �г� ���� ǥ�� ����
        public DescriptionControl2 descriptionControl;
        
        [Header("���� �г� ��� ����")]
        public Transform descriptionPanelArea;
    }

    public List<ElementData> elementDataList;

    [System.Serializable]
    public class ElementData {

        public ElementsButton1 elementsButton;
    }


    public void Start()
    {
        OnSetElementData();
        OnTogglesReset();
    }

    private void OnSetElementData()
    {
        elementDataList.Clear();
        ElementsButton1[] elementsButton1List=
            toggleGroup.GetComponentsInChildren<ElementsButton1>();
        for (int i=0;i< elementsButton1List.Length; i++) {
            ElementData elementData = new ElementData();
            elementData.elementsButton = elementsButton1List[i];
            elementDataList.Add(elementData);
        }
    }

    public void OnEnable()
    {
        OnTogglesReset();
    }
    public void OnDisable()
    {
        RemoveTogglesReset();
    }
    private Coroutine onTogglesReset = null;


    public void OnTogglesReset()
    {
        RemoveTogglesReset();
        onTogglesReset = StartCoroutine(TogglesReset());

    }

    private void RemoveTogglesReset()
    {
        if (onTogglesReset != null)
        {
            StopCoroutine(onTogglesReset);
            onTogglesReset = null;
        }
    }

    IEnumerator TogglesReset()
    {
        Debug.Log("TogglesReset1");
        toggleGroup.allowSwitchOff = true;
        yield return null;

        Debug.Log("TogglesReset2");
        for (int i = 0; i < elementDataList.Count; i++)
        {
            elementDataList[i].elementsButton.targetToggle.isOn = false;
        }
        yield return null;

        Debug.Log("TogglesReset3");
        //toggleGroup.allowSwitchOff = false;

    }


}
