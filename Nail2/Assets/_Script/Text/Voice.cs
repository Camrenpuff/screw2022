using ReadSpeaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Voice : MonoBehaviour
{
    public TTSSpeaker speaker;
    [TextArea] public String voice;
    // Start is called before the first frame update
    void Start()
    {
        TTS.Init();
    }

    // Update is called once per frame
    void Update()
    {
        //防止同时读取两句话
        if (!speaker.audioSource.isPlaying)
        {

        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TTS.Say(voice, speaker);
            print("说话");
        }
    }

    
          
    
}
