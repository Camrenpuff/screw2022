using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static UnityEditor.Progress;


public class EnableTeleport2 : MonoBehaviour
{
    //������������
   
    public int i;
    public int ?j;//�ڼ�����Ҫ����
    public GameObject voicePlateGroup;
    private Transform voicePlate;

    public bool islast = false;

    public SpeedTest speedTest;
    public bool isQT = false;//�Ƿ���Ҫ����

    private void Start()
    {
        //��һ�����Ӽ���
        voicePlateGroup.transform.GetChild(0).Find("FX_Hologram_Base").GetComponent<ParticleSystem>().Play();
        voicePlateGroup.transform.GetChild(0).Find("plate").GetComponent<TeleportationAnchor>().enabled = true;
        //if (!islast)
        //{
        //    //otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled = false;
        //    //otherTeleport.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
           

        //}

    }


    void Update()
    {

        if (isQT && speedTest.isTeleporting)
        {
            Nextpoint();
        }

    }


    //��һ�����͵���ʾ
    public void OnTriggerEnter(Collider other)
    {

        //if (!islast && other.CompareTag("Player") && !isQT)
        //{

        //    print("���Դ���");
        //    Nextpoint();

        //}
        if (other.CompareTag("����"))
        {
            
            //Debug.Log(voicePlate);
            //��ȡ��ײ�õ���voicePlate�ı��
            voicePlate = other.gameObject.transform;
            i = voicePlate.GetSiblingIndex();

            Nextpoint();
            
        }





    }

    void Nextpoint()
    {
        //�Լ���������ʧ
        voicePlate.Find("FX_Hologram_Base").GetComponent<ParticleSystem>().Stop();
        //��һ�����ӳ��ֲ��ҿɴ���
        voicePlateGroup.transform.GetChild(i + 1).Find("plate").GetComponent<Collider>().enabled = true;
        voicePlateGroup.transform.GetChild(i + 1).Find("FX_Hologram_Base").GetComponent<ParticleSystem>().Play();


        ////�Լ���������ʧ
        //this.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        ////��һ������
        //print(otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled);

        //otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled = true;
        //otherTeleport.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

    }





    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("����"))
        {
            print(voicePlate+"11111");
            voicePlate.Find("plate").GetComponent<Collider>().enabled =false;
        }

    }



    













}
