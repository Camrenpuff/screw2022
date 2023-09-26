using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    [SerializeField] private Animator myKey;
    [SerializeField] private Animator myScrew;

    [SerializeField] private Animator myKey1;
    [SerializeField] private Animator myScrew1;

    [SerializeField] private Animator myKey2;
    [SerializeField] private Animator myScrew2;

    //[SerializeField] private Animator myKey3;
    //[SerializeField] private Animator myScrew3;

    //[SerializeField] private Animator myKey4;
    //[SerializeField] private Animator myScrew4;

    //[SerializeField] private Animator myKey5;
    //[SerializeField] private Animator myScrew5;

    //[SerializeField] private Animator myKey6;
    //[SerializeField] private Animator myScrew6;

    //[SerializeField] private Animator myKey7;
    //[SerializeField] private Animator myScrew7;

    //[SerializeField] private Animator myKey8;
    //[SerializeField] private Animator myScrew8;

    //[SerializeField] private Animator myKey9;
    //[SerializeField] private Animator myScrew9;

    //[SerializeField] private Animator myKey10;
    //[SerializeField] private Animator myScrew10;

    [SerializeField] private string animKey="Kowtow";
    [SerializeField] private string animScrew = "Kowtow";
    [SerializeField] private float offsetTime=1f;
    [SerializeField] private float offsetTime1 = 1f;
    [SerializeField] private float offsetTime2 = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            offsetTime = Random.Range(1f, 5f);
            offsetTime1 = Random.Range(1f, 5f);

            myKey.Play(animKey, 0, offsetTime);
            myScrew.Play(animScrew, 0, offsetTime);

            myKey1.Play(animKey, 0, offsetTime1);
            myScrew1.Play(animScrew, 0, offsetTime1);

            myKey2.Play(animKey, 0, offsetTime2);
            myScrew2.Play(animScrew, 0, offsetTime2);
        }

    }
  
}
