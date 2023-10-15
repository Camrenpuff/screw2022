using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchPlateGroup : MonoBehaviour
{
    public int coT=0;
    public GameObject restrauntPos;
    public GameObject screw;
    public SceneTransitionManger sceneTransitionManger;
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
        print("Åö×²ÁË"+coT);
        //if (coT == 1)
        //{
        //    screw.transform.position = restrauntPos.transform.position;
        //    screw.transform.eulerAngles= restrauntPos.transform.localEulerAngles;
    
        //    sceneTransitionManger.GoToScene(coT);
        //    GameObject.DontDestroyOnLoad(this.gameObject);
        //}

        if (coT == 2)
        {
            //Destroy(enableTeleport1st);
            //enableTeleport2nd.enabled= true;

            //Destroy(restaurant1st);
            sceneTransitionManger.GoToScene(coT);
            GameObject.DontDestroyOnLoad(this.gameObject);
        }

        if (coT == 3)
        {
            //Destroy(enableTeleport2nd);
            //enableTeleport3th.enabled = true;

            //Destroy(restaurant2nd);
            sceneTransitionManger.GoToScene(coT);
            GameObject.DontDestroyOnLoad(this.gameObject);
        }


    }


}
