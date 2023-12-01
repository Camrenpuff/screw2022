using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;




//timeline����,���Ҷ���Ļ����fadeout��fadeIn,������������,ץȡ����send������message
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

        i += 1;//��һ������
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

