using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform des;
    public float speed=1.5f;
    
    public List<GameObject> animals = new List<GameObject>();
    public List<String> animations = new List<String>();
    public List<String> animationsIdle = new List<String>();

    private bool startmove;
    private float j=2;
    private int i = 1;//ÐòºÅ
    void Update()
    {
        
        if (startmove && j>1)
        {
            j = Vector3.Distance(des.position, animals[i].transform.position);

            animals[i].transform.position += speed * Time.deltaTime * (des.position - animals[i].transform.position);
            Debug.Log("j"+j);
            Debug.Log(animals[i]);
            Debug.Log("animals" + (des.position - animals[i].transform.position));
            Debug.Log("speed"+speed);
            Debug.Log("time"+Time.deltaTime);
        }
        if (j < 1)
        {
            startmove = false;
            animals[i].GetComponent<Animator>().Play(animationsIdle[i], 0, 1f);
            j = 1;
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tele"))
        {
            i += 1;
            Debug.Log("i" + i);
            Debug.Log("Åö×²"+other);
            //animals[i].GetComponent<Animator>().Play(animations[i], 0, 1f);
            startmove = true;

        } 
    }
}
    
