using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrdcTableControl : SceneControl
{

    public ElementsControl elementsControl;

    public CanvasGroup manCG;
    public void OnEnable()
    {
        manCG.gameObject.SetActive(true);
        manCG.alpha = 1;
    }

    //시작 컨트롤
    public override void OnInit(SceneControlManager.SceneObject sceneObject)
    {
        base.OnInit(sceneObject);
        //초기 진행시 버튼 토글 초기화 진행
        elementsControl.OnTogglesReset();
    }
}
