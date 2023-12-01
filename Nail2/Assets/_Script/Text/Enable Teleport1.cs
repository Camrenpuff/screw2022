using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
//using static UnityEditor.Progress;


public class EnableTeleport1 : MonoBehaviour
{
    //挂在主角身上
    //第几个儿子
    private int i;

    //第几个需要上香
    public int j;
    public int k;
    public int l =100;
    public SpeedTest speedTest1;
    public SpeedTest speedTest2;
    public SpeedTest? speedTest3;
    private bool isQT = false;//是否需要上香


    public GameObject voicePlateGroup;
    private Transform voicePlate;

    

    

    private void Start()
    {
        //第一个粒子激活
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
            //确保只运行一次
            Nextpoint();
            isQT= false;
            print("传送1");
        }

        if (isQT && speedTest2.isTeleporting)
        {

            Nextpoint();
            isQT = false;
            print("传送2");
            print(" isQT && speedTest2.isTeleporting");
        }

        if (isQT && speedTest3.isTeleporting)
        {
            Nextpoint();
            isQT = false;
            print("传送3");

        }

    }


    //下一个传送点显示
    public void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("盘子"))
        {
            
            //Debug.Log(voicePlate);
            //获取碰撞得到的voicePlate的编号
            voicePlate = other.gameObject.transform;
            i = voicePlate.GetSiblingIndex();

            //判断是否为关键词句
            if(j == i|| k == i || l == i)
            {
                isQT = true;
                print("j");
            }
            
            else
            {
                //处理下一个传送点
                Nextpoint();
                print(i);
            }
        }
    }

   

    void Nextpoint()
    {


        //自己的粒子消失
        voicePlate.Find("FX_Hologram_Base").GetComponent<ParticleSystem>().Stop();
        //下一个粒子出现并且可传送
        if (i < voicePlateGroup.transform.childCount - 1)
        {
            Transform nextPlate = voicePlateGroup.transform.GetChild(i + 1);
            nextPlate.Find("plate").GetComponent<Collider>().enabled = true;
            nextPlate.Find("FX_Hologram_Base").GetComponent<ParticleSystem>().Play();
        }

        ////自己的粒子消失
        //this.transform.GetChild(0).GetComponent<ParticleSystem>().Stop();
        ////下一个粒子
        //print(otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled);

        //otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled = true;
        //otherTeleport.transform.GetChild(0).GetComponent<ParticleSystem>().Play();

    }





    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("盘子"))
        {
            print(voicePlate+"11111");
            voicePlate.Find("plate").GetComponent<Collider>().enabled =false;
        }

    }



    













}
