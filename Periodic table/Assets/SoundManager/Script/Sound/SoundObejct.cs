using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������Ʈ
public class SoundObejct : MonoBehaviour
{
    //Ŭ�� ����
    [ReadOnly]
    public AudioClip clip;
    //����� �ҽ� ����
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
        
        Debug.Log("���� ���� �۵� ����");
        audioSource.Stop();
        GameObject.Destroy(this.gameObject);
    }

}
