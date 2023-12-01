using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMenu : MonoBehaviour
{
    public GameObject screw;
    public GameObject loc1;
    
    void OnClickStart()
    {
        screw.transform.position = loc1.transform.position;
    }

    //void OnClickQuit()
    //{
    //    screw.transform.position = loc1.transform.position;

    //}
}
