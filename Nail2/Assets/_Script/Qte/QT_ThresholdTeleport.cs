using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QT_ThresholdTeleport : MonoBehaviour
{
    //挂在传送点上,接收上香道具sendMessage,不放入prefab
    public bool isTeleporting = false;

    public SpeedTest speedtest;

    void Update()
    {
        if (speedtest.isTeleporting)
        {
            OnIncenseFinish();

        }
        
    }


    //上香结束后fillA>1后触发
    void OnIncenseFinish()
    {
        isTeleporting = true;

    }
}
