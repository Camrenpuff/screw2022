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
    
    
    public Image circle;
    //图片直接用!!!!

    public float fillA = 0;
    public float waitForSeconds = 0.02f;
    public float add = 0.2f;
    public float subtract = 0.02f;
    private bool Kowtow = false;
    private float timeThreshold = 0;
    public string eventSuccess = "n";
    public Material press;
    public Material pressExit;
    public MeshRenderer rend;
   
    //播放动画
    public InputActionManager inputActionManager;
    public PlayableDirector director;
    public GameObject rug;
    public GameObject screw;



    void Start()
    {
       
        
     
        //print(circle.fillAmount);
         

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            Kowtow = true;
            print("我磕头");
            rend.material= press;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            StartCoroutine("DelayTime");
            rend.material = pressExit;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Head"))
        {
            StartCoroutine("DelayTime");
            rend.material = pressExit;
            
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

        if (timeThreshold > 0.05f )
        {
            timeThreshold= 0;
            fillA -= subtract;
            
        }

        if(fillA<0)
        {
            fillA = 0;
        }
        
        circle.fillAmount = fillA;

        if(fillA > 1)
        {
            eventSuccess = "y";
            Debug.Log(eventSuccess);

            inputActionManager.enabled = false;
            director.Play();
            


            Invoke("FinishInvoke", (float)director.duration);
           

        }


    }


    void FinishInvoke()
    {
        print("不能动");
        inputActionManager.enabled = true;
        screw.transform.position = rug.transform.position;
    }









}
