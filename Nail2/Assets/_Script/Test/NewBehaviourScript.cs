using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Instantiate(obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
