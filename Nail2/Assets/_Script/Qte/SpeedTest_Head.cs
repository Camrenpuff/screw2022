using ReadSpeaker;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class SpeedTest_Head : MonoBehaviour
{
    //private float speed;

    private bool isSubstract = true;
    public Image circle;
    //图片直接用!!!!

    public float fillA = 0;
    public float waitForSeconds = 0.02f;
    public float add = 0.2f;
    public float subtract = 0.02f;
    private bool Kowtow = false;
    private float timeThreshold = 0;
    public string eventSuccess = "n";
    //public Material press;
    //public Material pressExit;
    //public MeshRenderer rend;

    //播放动画
    //public InputActionManager inputActionManager;
    //public PlayableDirector director;
    public bool isInMainScene;
    public SceneTransitionManger? sceneTransitionManger;
    

    public GameObject? rug;
    public GameObject screw;

    public FadeScreen fadeScreen;

    public AudioSource audioSource;
   

    [TextArea] public String voice;
    public TTSSpeaker speaker;




    void Start()
    {
       
        
     
        //audio= GetComponent<AudioSource>();
         

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            Kowtow = true;
            print("我磕头");
            //rend.material= press;
            //audio.clip = hitClip;
            audioSource.Play();
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            StartCoroutine("DelayTime");
            //rend.material = pressExit;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            StartCoroutine("DelayTime");
            //rend.material = pressExit;
            
        }
    }

    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(waitForSeconds);
        Kowtow = false;
        //print("我不磕头");
    }



    void Update()
    {


        //print("现在的百分比是" + fillA);
        if (Kowtow == true)
        {
           
            //print("磕头成功");
            fillA += add;
            
            
            
        }
        timeThreshold += Time.deltaTime;

        if (timeThreshold > 0.05f && isSubstract)
        {
            timeThreshold= 0;
            fillA -= subtract;
            
        }

        if(fillA<0)
        {
            fillA = 0;
        }
        
        circle.fillAmount = fillA;

        if(fillA > 1 )
        {
            //停止减少
            isSubstract = false;

            eventSuccess = "y";
            
            Debug.Log(eventSuccess);
            fillA = 1;//一次就可以
            
            StartCoroutine(FinishFadeOut());


        }


    }

    IEnumerator FinishFadeOut()
    {
        fadeScreen.FadeOut();
        if (isInMainScene)
        {
            TTS.Say(voice, speaker);
            yield return new WaitForSeconds(fadeScreen.fadeDuration);
            screw.transform.position = rug.transform.position;
            screw.transform.eulerAngles = rug.transform.localEulerAngles;
            yield return new WaitForSeconds(0.02f);
            fadeScreen.FadeIn();
        }
        if (!isInMainScene)
        {
            TTS.Say(voice, speaker);
            yield return new WaitForSeconds(fadeScreen.fadeDuration);
            sceneTransitionManger.GoToScene(1);
        }

        
    }
        

    //void FinishFadeOut()
    //{
    //    if (isInMainScene)
    //    {
    //        fadeScreen.FadeIn();
    //        screw.transform.position = rug.transform.position;
    //        screw.transform.eulerAngles = rug.transform.localEulerAngles;
    //    }
    //    else
    //    {
    //        sceneTransitionManger.GoToScene(1);
    //    }

    //}
    //void FinishInvoke()
    //{
    //    print("不能动");
    //    inputActionManager.enabled = true;
    //    screw.transform.position = rug.transform.position;
    //}









}
