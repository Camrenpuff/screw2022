using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject? loc;
    public GameObject XROrigin;

    public void OnPress()
    {
        XROrigin.transform.position = loc.transform.position;

    }
    
}
