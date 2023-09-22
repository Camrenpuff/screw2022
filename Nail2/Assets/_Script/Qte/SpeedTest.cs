using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTest : MonoBehaviour
{
    private float speed;
    public String testTarget;
    public Image circle;
    //public GameObject qtCircle;//图片直接用!!!!

    public float fillA = 0;
    private bool grabbing = false;


    //void Awake()
    //{
    //    GameObject.Instantiate(qtCircle);
    //    //得到子对象上挂载的脚本
    //    GameObject.Instantiate(qtCircle).GetComponentInChildren<Image>().fillAmount = fillA;

    //}

    void Start()
    {
       
        
        //Debug.Log(qtCircle);
        print(circle.fillAmount);


        StartCoroutine(CalcSpeed());
    }

    IEnumerator CalcSpeed()
    {
        bool isPlaying = true;
        while (isPlaying)
        {
            Vector3 prevPovs = transform.position;
            yield return new WaitForFixedUpdate();
            //找到更新的子对象
            speed = Mathf.RoundToInt(Vector3.Distance(this.transform.Find(testTarget).position, prevPovs) / Time.fixedDeltaTime);
            print(speed);
           

        }

    }

    //向QT_Event发消息
    void Update()
    {
       

        //if (qt_circle != null)
        //{
        //    qt_circle.fillAmount = fillA;
        //}

        if (speed > 0.01 && grabbing == true)
        {
            
            print("快速");
            fillA += 0.01f;
            print("现在的百分比是" + fillA);
        }

        circle.fillAmount = fillA;

    }

    //controller grabbing event
    void TestFun()
    {
        grabbing = true;
        print("我抓到螺丝头");
    }






}
