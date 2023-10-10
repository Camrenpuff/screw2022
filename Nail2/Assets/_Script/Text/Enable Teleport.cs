using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class EnableTeleport : MonoBehaviour
{
    public GameObject otherTeleport;

    

    public void OnTriggerEnter(Collider other)
    {
        otherTeleport.transform.GetComponent<TeleportationAnchor>().enabled= true;
        otherTeleport.transform.GetChild(1).GetComponent<ParticleSystem>().Play();

    }


    public void OnTriggerExit(Collider other)
    {
        this.GetComponent<TeleportationAnchor>().enabled = false;
        this.transform.GetChild(1).GetComponent<ParticleSystem>().Stop();

    }
}
