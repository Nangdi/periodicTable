using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameManager;

//�� ���� ��Ʈ��
public class DescriptionControl : MonoBehaviour
{

    public ElementType elementType;


    public TMP_Text descriptionName;


    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
      
    }

    public void OnInit() {
        Debug.Log("�г� ���� ����");
        this.gameObject.SetActive(true);
    }


    public void SetData(GameManager.ElementType elementType)
    {
        this.elementType = elementType;
        descriptionName.text = elementType.ToString();
    }


    public void OnClose() {
        Debug.Log("버튼꺼짐");

        this.gameObject.SetActive(false);
    }

}
