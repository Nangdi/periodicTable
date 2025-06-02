using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class Example
{

}

public class JsonManager : MonoBehaviour
{
    //������ json ��ü , ��μ���
    protected void SaveData<T>(T jsonObject, string path)
    {
       
        string json = JsonUtility.ToJson(jsonObject, true);
        File.WriteAllText(path, json);
        Debug.Log($"�����: {path}");
    }
    //��ȯ�� ����
    public T LoadData<T>( string path, Action saveMathod )
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning("JSON ������ �������� �ʽ��ϴ�.");
            saveMathod();
        }
        Debug.Log("JSON�ε�");
        string json = File.ReadAllText(path);
        T jsonData = JsonUtility.FromJson<T>(json);
        return jsonData;
    }
 
    //���� �����ڵ�
    //wrapper = JsonClass
    //filePath = Json ���
    //
    //public void SaveScanData()
    //{
    //    DataWrapper wrapper = new DataWrapper { objectDatas = dataList };
    //    SaveData(wrapper, filePath);
    //}
    //public List<ObjectScanData> LoadData()
    //{
    //    DataWrapper wrapper = LoadData<DataWrapper>(filePath, SaveScanData);
    //    return wrapper.objectDatas;
    //}

}
