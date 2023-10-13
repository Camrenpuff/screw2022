using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.XR.Interaction.Toolkit.Inputs;


//timeline����,���Ҷ���Ļ����fadeout��fadeIn,������������,ץȡ����send������message
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
        print("ѡ��");
       
        inputActionManager.enabled = false;
        director.Play();

        Invoke("FinishInvoke", (float)director.duration+ 5f);

    }

    void FinishInvoke()
    {
        print("���ܶ�");

        //�ϰְ�,true���游�����˶�
        //�ϰְ�,true���游�����˶�
        head.transform.SetParent(GameObject.Find("interior2").transform,true);
        
        inputActionManager.enabled = true;
        fadeScreen.FadeOut();
        //�Ƴ�fadeIn��ʱ��
        Invoke("FinishFadeOut", (float)fadeScreen.fadeDuration);
        
    }

    void FinishFadeOut()
    {
        fadeScreen.FadeIn();
        this.transform.position = rug.transform.position;
    }
}

