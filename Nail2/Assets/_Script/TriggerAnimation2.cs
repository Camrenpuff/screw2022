using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation2 : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> keyNPC ;
    

    

    [SerializeField] private string animKey = "Anim_KeyUpDown";
    [SerializeField] private string animScrew = "Kowtow";
    [SerializeField] private float offsetTime = 1f;
    

    private void OnTriggerEnter(Collider other)
    {
        
        
        

        foreach (GameObject item in keyNPC)
        {
            //Animator animator = item.transform.GetComponentInChildren<Animator>();

            //for(int i =0; i<item.transform.childCount; i++)
            //{
            //    offsetTime = Random.Range(1f, 5f);

            //    if (item.transform.GetChild(i).CompareTag("Screw"))
            //    {
            //        print(i + "¿ÄÍ·");

            //        item.transform.GetChild(i).GetComponent<Animator>().Play(animScrew, 0, offsetTime);
            //    }

            //    if (item.transform.GetChild(i).CompareTag("Key"))
            //    {
            //        print(i+"´ò×Ö");
            //        item.transform.GetChild(i).GetComponent<Animator>().Play(animKey, 0, offsetTime);
            //    }


            //}

            offsetTime = Random.Range(1f, 5f);

            item.transform.GetChild(0).GetComponent<Animator>().Play(animScrew, 0, offsetTime);

            item.transform.GetChild(1).GetComponent<Animator>().Play(animKey, 0, offsetTime);





        }

    }
}
