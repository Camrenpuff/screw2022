using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static UnityEditor.Progress;


public class EnableTeleport : MonoBehaviour
{
    public GameObject? otherTeleport;
    
    public bool islast = false;

    public SpeedTest? speedTest = null;
    public bool isQT = false;//�Ƿ���Ҫ����

    private void Start()
    {
        if (!islast)
        {
            otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled = false;
            otherTeleport.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();

        }

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
        
        if (!islast && other.CompareTag("Player") && !isQT)
        {
            
            print("���Դ���");
            Nextpoint();
            
        }
    }

    void Nextpoint()
    {
        //�Լ���������ʧ
        this.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        //��һ������
        print(otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled);

        otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled = true;
        otherTeleport.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

    }





    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.GetComponent<TeleportationAnchor>().enabled = false;
        }
        
        

    }
}
