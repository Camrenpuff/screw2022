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
    public SpeedTest speedTest;
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
        print(isQT && speedTest.isTeleporting);
        if (isQT && speedTest.isTeleporting)
        {
            //ȷ��ֻ����һ��
            Nextpoint();
            isQT= false;
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

            //�ж��Ƿ�Ϊ�ؼ��ʾ�
            if(j==i||k==i)
            {
                isQT = true;
            }
            else
            {
                //������һ�����͵�
                Nextpoint();
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
