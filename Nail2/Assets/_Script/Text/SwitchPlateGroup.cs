using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchPlateGroup : MonoBehaviour
{
    private int coT= 1;
    public GameObject restrauntPos;
    public GameObject screw;
    public SceneTransitionManger sceneTransitionManger;
    public float timeSwitch= 15f; 
    //public EnableTeleport1 enableTeleport1st;
    //public EnableTeleport1 enableTeleport2nd;
    //public EnableTeleport1? enableTeleport3th;
    //public GameObject restaurant1st;
    //public GameObject restaurant2nd;
    //public GameObject? restauran3th;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    

    private void OnTriggerEnter(Collider other)
    {
        coT += 1;
        //print("Åö×²ÁË"+coT);
        if (coT == 1 && other.CompareTag("Animals"))
        {
            StartCoroutine("WaitTime");  
        }

        


        if (coT == 2 && other.CompareTag("Animals"))
        {
            //Destroy(enableTeleport1st);
            //enableTeleport2nd.enabled= true;

            //Destroy(restaurant1st);
            sceneTransitionManger.GoToScene(coT);
            GameObject.DontDestroyOnLoad(this.gameObject);
        }



        if (coT == 3 && other.CompareTag("Animals"))
        {
            //Destroy(enableTeleport2nd);
            //enableTeleport3th.enabled = true;

            //Destroy(restaurant2nd);
            sceneTransitionManger.GoToScene(coT);
            GameObject.DontDestroyOnLoad(this.gameObject);
        }


    }

    public IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(timeSwitch);
        screw.transform.position = restrauntPos.transform.position;
        screw.transform.eulerAngles = restrauntPos.transform.localEulerAngles;

    }


}
