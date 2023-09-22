using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTest : MonoBehaviour
{
    private float speed;
    public String testTarget;
    public Image circle;
    //public GameObject qtCircle;//ͼƬֱ����!!!!

    public float fillA = 0;
    private bool grabbing = false;


    //void Awake()
    //{
    //    GameObject.Instantiate(qtCircle);
    //    //�õ��Ӷ����Ϲ��صĽű�
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
            //�ҵ����µ��Ӷ���
            speed = Mathf.RoundToInt(Vector3.Distance(this.transform.Find(testTarget).position, prevPovs) / Time.fixedDeltaTime);
            print(speed);
           

        }

    }

    //��QT_Event����Ϣ
    void Update()
    {
       

        //if (qt_circle != null)
        //{
        //    qt_circle.fillAmount = fillA;
        //}

        if (speed > 0.01 && grabbing == true)
        {
            
            print("����");
            fillA += 0.01f;
            print("���ڵİٷֱ���" + fillA);
        }

        circle.fillAmount = fillA;

    }

    //controller grabbing event
    void TestFun()
    {
        grabbing = true;
        print("��ץ����˿ͷ");
    }






}
