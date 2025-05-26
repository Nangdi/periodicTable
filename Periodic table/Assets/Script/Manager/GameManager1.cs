using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{

    #region Instance
    private static GameManager instance;

    public static GameManager Instance
    {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<GameManager>();
            }

            return instance;
        }
    }
    #endregion

    //����Ÿ�� ���� ����
    public enum ElementType {
        _1,_2,_3,_4,_5,_6,_7,_8,_9,_10,_11,_12,_13,_14,_15,_16,_17,_18,_19,_20
    }


    public void OnEnable()
    {
        OnInit();
    }

    /// <summary>
    /// �ʱ� ���� ���� 
    /// </summary>
    private void OnInit() {
        Debug.Log("�ʱ� ���� ���� ����");
    }

    /// <summary>
    /// ����
    /// </summary>
    public void OnReset() {
        Debug.Log("���� ���� ���� ");
    }







}
