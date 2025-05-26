using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WaitVideoClickButton : MonoBehaviour, IPointerClickHandler
{

    public SceneControlManager.SceneType nextSceneType;


    public void OnPointerClick(PointerEventData eventData)
    {
        SceneControlManager.Instance.OnLoadScene(nextSceneType);
    }
}
