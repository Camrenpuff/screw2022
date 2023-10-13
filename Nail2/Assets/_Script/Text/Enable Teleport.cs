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
    public bool isQT = false;//是否需要上香

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


    //下一个传送点显示
    public void OnTriggerEnter(Collider other)
    {
        
        if (!islast && other.CompareTag("Player") && !isQT)
        {
            
            print("可以传送");
            Nextpoint();
            
        }
    }

    void Nextpoint()
    {
        //自己的粒子消失
        this.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        //下一个粒子
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
