using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;




//timeline����,���Ҷ���Ļ����fadeout��fadeIn,������������,ץȡ����send������message
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
        print("ѡ��");

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
    ////    print("���ܶ�");

    ////    //�ϰְ�,true���游�����˶�,transform��Ϊ�Ը�����ΪԲ��

    ////    head.transform.SetParent(GameObject.Find("interior2").transform,true);

    ////    //inputActionManager.enabled = true;
    ////    fadeScreen.FadeOut();
    ////    //�Ƴ�fadeIn��ʱ��
    ////    Invoke("FinishFadeOut", (float)fadeScreen.fadeDuration);

    ////}

    ////void FinishFadeOut()
    ////{
    ////    fadeScreen.FadeIn();
    ////    this.transform.position = rug.transform.position;
    ////}
}

