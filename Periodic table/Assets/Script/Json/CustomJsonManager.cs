using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[Serializable]
public class ObjectScanData
{
    public int objectID;
    public int cropSize;
    public int startOffset;
    public int offsetX;
    public int offsetY;
}
[Serializable]
public class PortJson
{
    public string com = "COM4";
    public int baudLate = 19200;
}
[Serializable]
public class DataWrapper
{
    public List<ObjectScanData> objectDatas;
}

public class CustomJsonManager : JsonManager
{
    // Start is called before the first frame update
    public static CustomJsonManager jsonManager { get; private set; }

   
    private string filePath;
    private string portPath;

    //[Header("����������")]
    //public List<ObjectScanData> dataList;
    //public List<GameObject> objectList;

    // Update is called once per frame
    private void Awake()
    {
        if (jsonManager == null)
        {
            jsonManager = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        DataInit();
        //filePath = Path.Combine(Application.persistentDataPath, "objectData.json");
        portPath = Path.Combine(Application.streamingAssetsPath, "port.json");
        //dataList = LoadData();
        //��ĵ����Ÿ JOSN �ε� ���� �ذ��ؾ���
    }



    public void DataInit()
    {
        
        //dataList = new List<ObjectScanData>()
        //{
        //    new ObjectScanData { objectID = 0, cropSize = 1509, startOffset = 0, offsetX = 0, offsetY = 300 },
        //    new ObjectScanData { objectID = 1, cropSize = 1550, startOffset = 0, offsetX = 0, offsetY = 300 },
        //    new ObjectScanData { objectID = 2, cropSize = 1550, startOffset = 0, offsetX = 0, offsetY = 300 }
        //};

    }
    //������ json ��ü , ��μ���
    //JsonClass = JsonClass
    //filePath = Json ���
    //public void SaveScanData()
    //{
    // ��� �Ұ��
    //    DataWrapper wrapper = new DataWrapper { objectDatas = dataList };
    // �Ѱ��� �Ұ��
    //    JsonClass json = new JsonClass();
    //    SaveData(wrapper(json), filePath);
    //}
    //public List<ObjectScanData> LoadData()
    //{
    //    DataWrapper wrapper = LoadData<DataWrapper>(filePath, SaveScanData);
    //    return wrapper.objectDatas;
    //}


    //Port ����, �ε� �޼ҵ�
    public void SavePortJson()
    {
        PortJson portJson = new PortJson();
        SaveData(portJson, portPath);
    }
    public PortJson LoadPortData()
    {
        return LoadData<PortJson>(portPath, SavePortJson);
    }
}
