using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTest : MonoBehaviour
{
    private float speed;
    
    
    public Image circle;
    //public GameObject qtCircle;//ͼƬֱ����!!!!

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
    //        //�ҵ����µ��Ӷ���
    //        //speed = Mathf.RoundToInt(Vector3.Distance(this.transform.Find(testTarget).position, prevPovs) / Time.fixedDeltaTime);
    //        //speed=Mathf.RoundToInt(Vector3.Distance(screw.transform.position, prevPovs)/Time.fixedDeltaTime);
            
    //        print(speed);
           
            

    //    }

    //}

    //��QT_Event����Ϣ
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
           
            print("����");
            fillA += 0.005f;
            print("���ڵİٷֱ���" + fillA);
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
        print("��ץ����˿ͷ");
    }

    void TestFun2()
    {
        grabbing = false;
        print("�ҷ�����˿ͷ");
        fillA= 0;
    }






}
