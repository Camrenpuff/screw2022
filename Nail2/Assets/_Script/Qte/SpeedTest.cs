using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTest : MonoBehaviour
{
    private float speed;
    
    
    public Image circle;
    //public GameObject qtCircle;//图片直接用!!!!

    public float fillA = 0;
    private bool grabbing = false;
    public float timeThreshold = 0;
    public Rigidbody rigidbody;


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
         

        //StartCoroutine(CalcSpeed());
    }

    //IEnumerator CalcSpeed()
    //{
    //    bool isPlaying = true;
    //    while (isPlaying)
    //    {
    //        Vector3 prevPovs = transform.position;
    //        yield return new WaitForFixedUpdate();
    //        //找到更新的子对象
    //        //speed = Mathf.RoundToInt(Vector3.Distance(this.transform.Find(testTarget).position, prevPovs) / Time.fixedDeltaTime);
    //        //speed=Mathf.RoundToInt(Vector3.Distance(screw.transform.position, prevPovs)/Time.fixedDeltaTime);
            
    //        print(speed);
           
            

    //    }

    //}

    //向QT_Event发消息
    void Update()
    {

        speed = Mathf.Abs(rigidbody.velocity.y);
        print(speed);
        print(rigidbody.velocity.y);
        //if (qt_circle != null)
        //{
        //    qt_circle.fillAmount = fillA;
        //}

        if (speed > 1 && grabbing == true)
        {
           
            print("快速");
            fillA += 0.005f;
            print("现在的百分比是" + fillA);
        }
        timeThreshold += Time.deltaTime;

        if (timeThreshold > 0.1f && speed < 1 && grabbing == true)
        {
            timeThreshold= 0;
            fillA -= 0.01f;
            
        }
        
        circle.fillAmount = fillA;

    }

    //controller grabbing event
    void TestFun()
    {
        grabbing = true;
        print("我抓到螺丝头");
    }

    void TestFun2()
    {
        grabbing = false;
        print("我放下螺丝头");
        fillA= 0;
    }






}
