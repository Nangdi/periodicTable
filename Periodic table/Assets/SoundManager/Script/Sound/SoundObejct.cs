using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//사운드 오브젝트
public class SoundObejct : MonoBehaviour
{
    //클립 정보
    [ReadOnly]
    public AudioClip clip;
    //오디오 소스 정보
    public AudioSource audioSource;
    private Coroutine onSoundEnd = null;

    public void OnInit() {
        if (clip)
        {
            OnRemoveSoundEnd();
            onSoundEnd = StartCoroutine(OnSoundEnd());
        }
    }


    public void OnDisable()
    {
        OnRemoveSoundEnd();
    }

    private void OnRemoveSoundEnd() {
        if (onSoundEnd != null) {
            StopCoroutine(onSoundEnd);
            onSoundEnd = null;
        }
    }


    IEnumerator OnSoundEnd() {
        audioSource.clip = clip;
        audioSource.Play();
        yield return new WaitForSeconds(clip.length);
        
        Debug.Log("사운드 종료 작동 구간");
        audioSource.Stop();
        GameObject.Destroy(this.gameObject);
    }

}
