using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;




//timeline运行,并且对屏幕进行fadeout和fadeIn,挂在主角身上,抓取物体send给主角message
public class TriggerTimeLine : MonoBehaviour
{

    public PlayableDirector director;
    public GameObject rug;
    public GameObject? head;
    //public GameObject mainCamera;

    //public InputActionManager inputActionManager;

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
        animTime = (float)director.duration;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnSelectProp()
    {
        print("选择");

        //inputActionManager.enabled = false;
        //director.Play();
        StartCoroutine("StartFadeScreen");

        //Invoke("FinishInvoke", (float)director.duration+ 5f);

    }


    public IEnumerator StartFadeScreen()
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(screenfadeTime);
        fadeScreen.FadeIn();
        yield return new WaitForSeconds(screenfadeTime);
        //CameraSwitcher.SwitchCamera(FirstSceneCam);

        //this.transform.position = rug.transform.position;
        director.Play();
        yield return new WaitForSeconds(animTime);
        
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(screenfadeTime);
        fadeScreen.FadeIn();
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

