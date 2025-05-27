using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static ElementsControl;

[CustomEditor(typeof(ElementsControl))]

public class ElementsControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ElementsControl targetElementsControl =  target as ElementsControl;

        if (GUILayout.Button("하위 항목 등록 설정(배열 등록)")) {
            SettData(targetElementsControl);
        }
    }


    private void OnElementsReset(ElementsControl elementsControl) {
        elementsControl.elementDataList.Clear();
        Transform[] elementsButtonList = elementsControl.GetComponentsInChildren<Transform>();

        for (int i= elementsButtonList.Length-1;i>=0 ;i--) {
            
            GameObject targetObject = elementsButtonList[i].gameObject;
            if (!targetObject.transform.Equals(elementsControl.transform))
            {
                GameObject.DestroyImmediate(targetObject);
            }
        }

        elementsButtonList = elementsControl.elementsParentTF.GetComponentsInChildren<Transform>();

        for (int i = elementsButtonList.Length - 1; i >= 0; i--)
        {

            GameObject targetObject = elementsButtonList[i].gameObject;
            if (!targetObject.transform.Equals(elementsControl.elementsParentTF))
            {
                GameObject.DestroyImmediate(targetObject);
            }
        }

        DescriptionControl[] descriptionControlList = elementsControl.descriptionData.descriptionPanelArea.GetComponentsInChildren<DescriptionControl>();
        for (int i = descriptionControlList.Length - 1; i >= 0; i--)
        {
            GameObject targetObject = descriptionControlList[i].gameObject;
            if (!targetObject.transform.Equals(elementsControl.transform))
            {
                GameObject.DestroyImmediate(targetObject);
            }
        }

    }


    //데이터 등록 설정 구간
    public void SettData(ElementsControl elementsControl) {
        OnElementsReset(elementsControl);
        ElementsButton[] elementsButtonList = elementsControl.GetComponentsInChildren<ElementsButton>();
        int index = 0;
        for (int i=0;i<18;i++) {
            for (int j=0; j< 9 ; j++) {
                if (Enum.IsDefined(typeof(GameManager.ElementType), index))
                {
                    ElementsButton
                     elementButtonPrefab = null;
                    if ((index >= 92 && index <= 106) || (index >= 124 && index <= 138)) {
                        elementButtonPrefab =
                            GameObject.Instantiate<ElementsButton>(elementsControl.elementsPrefab, elementsControl.elementsParentTF);
                    }
                    else {
                        elementButtonPrefab =
                            GameObject.Instantiate<ElementsButton>(elementsControl.elementsPrefab, elementsControl.transform);
                    }
                    
                    ElementsButton elementData = new ElementsButton();
                    elementData = elementButtonPrefab;
                    elementsControl.elementDataList.Add(elementData);
                    GameManager.ElementType elementType = (GameManager.ElementType)index;
                    elementButtonPrefab.SetData(elementType);
                    elementButtonPrefab.name = elementType.ToString();
                     
                    DescriptionControl
                        descriptionPanelPrefab =
                            GameObject.Instantiate<DescriptionControl>(elementsControl.descriptionData.descriptionControl, elementsControl.descriptionData.descriptionPanelArea);
                    descriptionPanelPrefab.name = "descriptionPanel_" + elementType;
                    elementButtonPrefab.descriptionControl = descriptionPanelPrefab;
                    descriptionPanelPrefab.SetData(elementType);

                    elementButtonPrefab.targetToggle.group = elementsControl.toggleGroup;

                    EditorUtility.SetDirty(descriptionPanelPrefab);
                }
                else {
                    //더미 오브젝트 등록
                    GameObject
                     dummyPrefab =
                        GameObject.Instantiate(elementsControl.dummyPrefab, elementsControl.transform);



                }
                ++index;
            }
        }

    }





}

