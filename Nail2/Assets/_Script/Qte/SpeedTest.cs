using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTest : MonoBehaviour
{
    private float speed;
    [HideInInspector] public bool isTeleporting=false;//必须是public,因为被引用


    public Image circle;
    //图片直接用!!!!

    public float fillA = 0;
    private bool grabbing = false;
    [HideInInspector] public float timeThreshold = 0;
    public Rigidbody rigidBody;
    
   
    


    //void Awake()
    //{
    //    GameObject.Instantiate(qtCircle);
    //    //得到子对象上挂载的脚本
    //    GameObject.Instantiate(qtCircle).GetComponentInChildren<Image>().fillAmount = fillA;

    //}

    void Start()
    {
        
    }

   

    //向QT_Event发消息
    void Update()
    {
        //求速度
        if (grabbing)
        {
            speed = Mathf.Abs(rigidBody.velocity.y);
        }
        //print(circle.fillAmount);
        //print(speed);
        //print(rigidbody.velocity.y);


        if (speed > 1 && grabbing == true)
        {
           
            //print("快速");
            fillA += 0.005f;
            //print("现在的百分比是" + fillA);
        }
        timeThreshold += Time.deltaTime;

        if (timeThreshold > 0.1f && speed < 1 && grabbing == true)
        {
            timeThreshold= 0;
            fillA -= 0.01f;
            
        }
        
        //成功上香
        if (fillA >= 1)
        {
            isTeleporting = true;
            print("成功上香");
            StartCoroutine("DelayTime");
        }
        
        circle.fillAmount = fillA;

    }


    IEnumerator DelayTime()
    {
        yield return new WaitForSeconds(1);
       
        isTeleporting = false;
    }

    //controller grabbing event
    void TestFun()
    {
        grabbing = true;
        //print("我抓到螺丝头");
    }

    //controller putting down
    void TestFun2()
    {
        grabbing = false;
        //print("我放下螺丝头");
        fillA= 0;
    }






}
