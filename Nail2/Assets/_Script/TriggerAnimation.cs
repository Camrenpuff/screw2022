using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator myKey;
    [SerializeField] private string anim="Kowtow";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myKey.Play(anim, 0, 0.0f);
        }
    }
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }
}
