using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static SceneControlManager;

public class ElementsControl : MonoBehaviour
{
    //���� ������ ���� 
    public ElementsButton elementsPrefab;

    public Transform elementsParentTF;

    //���� ������ ����
    public GameObject dummyPrefab;

    public ToggleGroup toggleGroup;


    [Header("���� ���� ��� ���� ����")]
    public DescriptionData descriptionData;

    [System.Serializable]
    public class DescriptionData { 
        //�� �г� ���� ǥ�� ����
        public DescriptionControl descriptionControl;
        
        [Header("���� �г� ��� ����")]
        public Transform descriptionPanelArea;
    }

    public List<ElementsButton> elementDataList;

    [System.Serializable]
    public class ElementData {

        public ElementsButton elementsButton;
    }

    private void Awake()
    {
        GameManager.Instance.elementList = elementDataList;
    }
    public void Start()
    {
        //yield reutrn 
        OnTogglesReset();
        
    }

    public void OnEnable()
    {
        OnTogglesReset();
        Debug.Log("Enable");
    }


    public void OnDisable()
    {
        RemoveTogglesReset();
    }
    private Coroutine onTogglesReset = null;


    public void OnTogglesReset() {
        RemoveTogglesReset();
        onTogglesReset= StartCoroutine(TogglesReset());
      
    }

    private void RemoveTogglesReset() {
        if (onTogglesReset != null) {
            StopCoroutine(onTogglesReset);
            onTogglesReset = null;
        }
    }

    IEnumerator TogglesReset() {
        /*toggleGroup.allowSwitchOff = true;
        yield return null;
        for (int i = 0; i < elementDataList.Count; i++)
        {
            elementDataList[i].elementsButton.targetToggle.isOn = false;
        }
        yield return null;
        toggleGroup.allowSwitchOff = false;*/
        Debug.Log("TogglesReset1");
        toggleGroup.allowSwitchOff = true;
        yield return null;

        Debug.Log("TogglesReset2");
        for (int i = 0; i < elementDataList.Count; i++)
        {
            elementDataList[i].targetToggle.isOn = false;
        }
        yield return null;

        Debug.Log("TogglesReset3");
        toggleGroup.allowSwitchOff = false;
        //SceneControlManager.Instance.OnLoadScene(SceneType.StandbyVideo);

    }

}
