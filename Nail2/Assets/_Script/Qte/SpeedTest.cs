using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTest : MonoBehaviour
{
    private float speed;
    
    
    public Image circle;
    //ͼƬֱ����!!!!

    public float fillA = 0;
    private bool grabbing = false;
    public float timeThreshold = 0;
    public Rigidbody rigidbody;


    //void Awake()
    //{
    //    GameObject.Instantiate(qtCircle);
    //    //�õ��Ӷ����Ϲ��صĽű�
    //    GameObject.Instantiate(qtCircle).GetComponentInChildren<Image>().fillAmount = fillA;

    //}

    void Start()
    {
       
        
     
        print(circle.fillAmount);
         

        
    }

   

    //��QT_Event����Ϣ
    void Update()
    {
        //���ٶ�
        speed = Mathf.Abs(rigidbody.velocity.y);
        //print(speed);
        //print(rigidbody.velocity.y);
       

        if (speed > 1 && grabbing == true)
        {
           
            //print("����");
            fillA += 0.005f;
            //print("���ڵİٷֱ���" + fillA);
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
        //print("��ץ����˿ͷ");
    }

    //controller putting down
    void TestFun2()
    {
        grabbing = false;
        //print("�ҷ�����˿ͷ");
        fillA= 0;
    }






}
