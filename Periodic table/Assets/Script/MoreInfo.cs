using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class MoreInfo : MonoBehaviour

{
    public GameObject page;
    public CanvasGroup page0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickNext()
    {
        page.SetActive(true);
        page0.DOFade(1,0.5f);
    }
}
