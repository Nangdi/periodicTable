using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ��Ʈ��
public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    private static SoundManager instance = null;

    public static SoundManager Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<SoundManager>();
            }
            return instance;
        }
    }

   

    public enum SoundType { btn,shutter,ī��Ʈ,noSelect,select,��������,���л���,������������,
        �����, ���̼ǿϷ�,�����Ҹ�,����, ����1,�浹
    }

    //���� ������ ����Ʈ ����
    public List<SoundData> soundDataList;
    [System.Serializable]
    public class SoundData {
        public AudioClip clip;
        public SoundType soundType;
    }

    public SoundObejct soundObejct;

    public void CreateTestSound() {
        CreateSound(SoundType.shutter);
    }

    //���� ���� 
    public void CreateSound(SoundType soundType) {

        int index=soundDataList.FindIndex(item => item.soundType.Equals(soundType));
        if (index > -1) {
           
            SoundObejct _soundObejct = GameObject.Instantiate<SoundObejct>(soundObejct, this.transform);
            _soundObejct.clip = soundDataList[index].clip;
            _soundObejct.OnInit();
        }

    }

}
