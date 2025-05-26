using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static SoundManager;

public class SceneChangeButton : MonoBehaviour, IPointerClickHandler
{
    public SceneControlManager.SceneType nextSceneType;


    public void OnPointerClick(PointerEventData eventData)
    {
        SceneControlManager.Instance.OnLoadScene(nextSceneType);
        SoundManager.Instance.CreateSound(SoundType.shutter);
    }
}
