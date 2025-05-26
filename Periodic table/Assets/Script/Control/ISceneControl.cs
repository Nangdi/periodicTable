using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ISceneControl
{
    void OnInit(SceneControlManager.SceneObject sceneObject);


    void OnDisable();

}
