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

    //���� ��Ʈ��
    public override void OnInit(SceneControlManager.SceneObject sceneObject)
    {
        base.OnInit(sceneObject);
        //�ʱ� ����� ��ư ��� �ʱ�ȭ ����
        elementsControl.OnTogglesReset();
    }
}
