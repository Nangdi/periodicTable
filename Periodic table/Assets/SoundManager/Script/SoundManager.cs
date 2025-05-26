using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사운드 컨트롤
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

   

    public enum SoundType { btn,shutter,카운트,noSelect,select,성공사운드,실패사운드,스테이지시작,
        쾅사운드, 모든미션완료,물방울소리,폭발, 폭발1,충돌
    }

    //사운드 데이터 리스트 정보
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

    //사운드 생성 
    public void CreateSound(SoundType soundType) {

        int index=soundDataList.FindIndex(item => item.soundType.Equals(soundType));
        if (index > -1) {
           
            SoundObejct _soundObejct = GameObject.Instantiate<SoundObejct>(soundObejct, this.transform);
            _soundObejct.clip = soundDataList[index].clip;
            _soundObejct.OnInit();
        }

    }

}
