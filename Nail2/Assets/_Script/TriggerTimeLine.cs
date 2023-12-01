using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;




//timeline运行,并且对屏幕进行fadeout和fadeIn,挂在主角身上,抓取物体send给主角message
public class TriggerTimeLine : MonoBehaviour
{
    public GameObject XROrigin;
    public List<PlayableDirector> director = new List<PlayableDirector>();
    public List<GameObject> rugDes = new List<GameObject>();
    private int i=0;
    

    public FadeScreen fadeScreen;
    private float screenfadeTime;
    private float animTime;

    //[SerializeField] CinemachineVirtualCamera FirstPersonCam;
    //[SerializeField] CinemachineVirtualCamera FirstSceneCam;

    //private void OnEnable()
    //{
    //    CameraSwitcher.Register(FirstPersonCam);
    //    CameraSwitcher.Register(FirstSceneCam);
    //    CameraSwitcher.SwitchCamera(FirstPersonCam);
    //}

    //private void OnDisable()
    //{
    //    CameraSwitcher.Register(FirstPersonCam);
    //    CameraSwitcher.Register(FirstSceneCam);
    //}


    void Start()
    {
        screenfadeTime = fadeScreen.fadeDuration;
        //animTime = (float)director.duration;
        

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelectProp()
    {
        
        if (i < 3)
        {
            StartCoroutine("StartFadeScreen");
        }
        //inputActionManager.enabled = false;
        //director.Play();
        
    }


    public IEnumerator StartFadeScreen()
    {
        
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(screenfadeTime);
        fadeScreen.FadeIn();
        //yield return new WaitForSeconds(screenfadeTime/2);
        //CameraSwitcher.SwitchCamera(FirstSceneCam);

        XROrigin.transform.position = rugDes[i].transform.position;
        director[i].Play();
        yield return new WaitForSeconds(animTime);
        
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(screenfadeTime);
        fadeScreen.FadeIn();

        i += 1;//下一个动画
    }

    ////void FinishInvoke()
    ////{
    ////    print("不能动");

    ////    //认爸爸,true跟随父对象运动,transform改为以父对象为圆心

    ////    head.transform.SetParent(GameObject.Find("interior2").transform,true);

    ////    //inputActionManager.enabled = true;
    ////    fadeScreen.FadeOut();
    ////    //推迟fadeIn的时间
    ////    Invoke("FinishFadeOut", (float)fadeScreen.fadeDuration);

    ////}

    ////void FinishFadeOut()
    ////{
    ////    fadeScreen.FadeIn();
    ////    this.transform.position = rug.transform.position;
    ////}
}

