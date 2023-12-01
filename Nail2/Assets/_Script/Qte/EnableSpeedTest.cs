using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//∑¿÷πSpeedTest∑±√¶
public class EnableSpeedTest : MonoBehaviour
{
    public GameObject grabProp;
    public void OnTriggerEnter(Collider other)
    {
        grabProp.GetComponent<SpeedTest>().enabled = true;
        grabProp.GetComponent<XRGrabInteractable>().enabled = true;
    }
    public void OnTriggerExit(Collider other)
    {
        grabProp.GetComponent<SpeedTest>().enabled = false;
        grabProp.GetComponent<XRGrabInteractable>().enabled = false;
    }
}
