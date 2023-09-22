using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;


public class QT_Event : MonoBehaviour
{

    public float fillAmount = 0;
    private bool grabbing = false;
    private bool isKowtow = false;
    void Start()
    {
        
    }

   
    void Update()
    {
      
        if (grabbing == true && isKowtow ==true)
        {
            print("我有速度" );
            Debug.Log("grabbing");
            fillAmount += .2f;
        }

        this.GetComponentInChildren<Image>(true).fillAmount = fillAmount;
        
    }

    

    //controller grabbing event
    void TestFun()
    {
        grabbing = true;
        print("我抓到螺丝头");
    }

    void IsKowtow()
    {
        print("我磕头");
        isKowtow = true;
    }

    void NotKowtow()
    {
        isKowtow = false;
    }




}
