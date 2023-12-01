using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static UnityEditor.Progress;


public class EnableTeleport1 : MonoBehaviour
{
    //������������
    //�ڼ�������
    private int i;

    //�ڼ�����Ҫ����
    public int j;
    public int k;
    public int l =100;
    public SpeedTest speedTest1;
    public SpeedTest speedTest2;
    public SpeedTest? speedTest3;
    private bool isQT = false;//�Ƿ���Ҫ����


    public GameObject voicePlateGroup;
    private Transform voicePlate;

    

    

    private void Start()
    {
        //��һ�����Ӽ���
        Transform first = voicePlateGroup.transform.GetChild(0);
        first.Find("FX_Hologram_Base").GetComponent<ParticleSystem>().Play();
        first.Find("plate").GetComponent<TeleportationAnchor>().enabled = true;
        //if (!islast)
        //{
        //    //otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled = false;
        //    //otherTeleport.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
           

        //}

    }


    void Update()
    {
        //print(isQT && speedTest1.isTeleporting);
        //Debug.Log("isQT" + isQT);
        //Debug.Log("1"+speedTest1.isTeleporting);
        //Debug.Log("2" + speedTest2.isTeleporting);
        //Debug.Log("3"+speedTest3.isTeleporting);
        if (isQT && speedTest1.isTeleporting)
        {
            //ȷ��ֻ����һ��
            Nextpoint();
            isQT= false;
            print("����1");
        }

        if (isQT && speedTest2.isTeleporting)
        {

            Nextpoint();
            isQT = false;
            print("����2");
            print(" isQT && speedTest2.isTeleporting");
        }

        if (isQT && speedTest3.isTeleporting)
        {
            Nextpoint();
            isQT = false;
            print("����3");

        }

    }


    //��һ�����͵���ʾ
    public void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("����"))
        {
            
            //Debug.Log(voicePlate);
            //��ȡ��ײ�õ���voicePlate�ı��
            voicePlate = other.gameObject.transform;
            i = voicePlate.GetSiblingIndex();

            //�ж��Ƿ�Ϊ�ؼ��ʾ�
            if(j == i|| k == i || l == i)
            {
                isQT = true;
                print("j");
            }
            
            else
            {
                //������һ�����͵�
                Nextpoint();
                print(i);
            }
        }
    }

   

    void Nextpoint()
    {


        //�Լ���������ʧ
        voicePlate.Find("FX_Hologram_Base").GetComponent<ParticleSystem>().Stop();
        //��һ�����ӳ��ֲ��ҿɴ���
        if (i < voicePlateGroup.transform.childCount - 1)
        {
            Transform nextPlate = voicePlateGroup.transform.GetChild(i + 1);
            nextPlate.Find("plate").GetComponent<Collider>().enabled = true;
            nextPlate.Find("FX_Hologram_Base").GetComponent<ParticleSystem>().Play();
        }

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
