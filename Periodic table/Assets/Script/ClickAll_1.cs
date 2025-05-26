using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static SoundManager;

public class ClickAll_1 : MonoBehaviour
{
    bool a;
    public Button aa;
    // public GameObject page;
    public CanvasGroup pageA;
    public GameObject page0;
    public CanvasGroup page1;
    public CanvasGroup ele1;
    public GameObject btns;
    public GameObject leftWin;
    bool check;

    float timer;
    // public Button cc;
    // Start is called before the first frame update
    void Start()
    {
        page0.transform.DOScale(0, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(a == true)
        {
            timer += Time.deltaTime;
            // page.SetActive(true);
            
            if(timer > 2f)
            {
                page1.DOFade(0,0.1f);
                page0.transform.DOScale(1.2f, 0.5f);
                page0.transform.Translate(new Vector3(-90,120,0.5f));
                leftWin.transform.DOScale(0.9f, 0.5f);
                leftWin.transform.DOMove(new Vector3(3030,860,0),0.5f);
                ele1.DOFade(0,0.5f);
                SoundManager.Instance.CreateSound(SoundType.모든미션완료);
                GameManager.Instance.eg.SetActive(true);
                a = false;
                btns.SetActive(false);
                check = true;
            }
        }
    }

    public void OnclickButton1()
    {
        a = true;
        pageA.DOFade(1,0.5f);
    }
    public void OnclickOutButton()
    {
        pageA.DOFade(0,0.5f);
        page0.transform.DOScale(0, 0.1f);
        page1.DOFade(1,0.5f);
        timer = 0;
        a = false;
        if(check==true){
            page0.transform.Translate(new Vector3(80,-120,0));
            btns.SetActive(true);
            leftWin.transform.DOScale(1f, 0.1f);
            leftWin.transform.DOMove(new Vector3(3330f,901f,0),0.1f);
            ele1.DOFade(1,0.1f);
            check = false;
        }
        
    }
    
}
