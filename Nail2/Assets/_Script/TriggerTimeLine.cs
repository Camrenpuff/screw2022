using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


//timeline运行,并且对屏幕进行fadeout和fadeIn,挂在主角身上,抓取物体send给主角message
public class TriggerTimeLine : MonoBehaviour
{

    public PlayableDirector director;
    public GameObject rug;
    public GameObject head;
    public InputActionManager inputActionManager;
    
    public FadeScreen fadeScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartOnSelect()
    {
        print("选择");
       
        inputActionManager.enabled = false;
        director.Play();

        Invoke("FinishInvoke", (float)director.duration+ 5f);

    }

    void FinishInvoke()
    {
        print("不能动");

        //认爸爸,true跟随父对象运动
        //认爸爸,true跟随父对象运动
        head.transform.SetParent(GameObject.Find("interior2").transform,true);
        
        inputActionManager.enabled = true;
        fadeScreen.FadeOut();
        //推迟fadeIn的时间
        Invoke("FinishFadeOut", (float)fadeScreen.fadeDuration);
        
    }

    void FinishFadeOut()
    {
        fadeScreen.FadeIn();
        this.transform.position = rug.transform.position;
    }
}

