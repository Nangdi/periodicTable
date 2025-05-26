using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static GameManager1;
using static SoundManager;

//�� ���� ��Ʈ��
public class DescriptionControl2 : MonoBehaviour
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
        // Debug.Log("�г� ���� ����");
        this.gameObject.SetActive(true);
    }


    public void SetData(GameManager1.ElementType elementType)
    {
        this.elementType = elementType;
        descriptionName.text = elementType.ToString();
    }


    public void OnClose() {
        this.gameObject.SetActive(false);
    }

}
