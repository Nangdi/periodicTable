using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PrdcTableControl2 : SceneControl
{

    public ElementsControl1 elementsControl;
    public CanvasGroup chaCG;

    public void OnEnable()
    {
        chaCG.gameObject.SetActive(true);
        chaCG.alpha = 1;
    }

    //���� ��Ʈ��
    public override void OnInit(SceneControlManager.SceneObject sceneObject)
    {
        base.OnInit(sceneObject);
        //초기 진행시 버튼 토글 초기화 진행
        elementsControl.OnTogglesReset();
    }
}
