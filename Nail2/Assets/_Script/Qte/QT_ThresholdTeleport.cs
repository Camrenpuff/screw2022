using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QT_ThresholdTeleport : MonoBehaviour
{
    //���ڴ��͵���,�����������sendMessage,������prefab
    public bool isTeleporting = false;

    public SpeedTest speedtest;

    void Update()
    {
        if (speedtest.isTeleporting)
        {
            OnIncenseFinish();

        }
        
    }


    //���������fillA>1�󴥷�
    void OnIncenseFinish()
    {
        isTeleporting = true;

    }
}
