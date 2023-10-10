using ReadSpeaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Voice : MonoBehaviour
{
    public TTSSpeaker speaker;
    public String voice;
    // Start is called before the first frame update
    void Start()
    {
        TTS.Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!speaker.audioSource.isPlaying)
        {

        }
    }


    public void OnTriggerEnter(Collider other)
    {
        TTS.Say(voice, speaker);
        print("Ëµ»°");
    }
}
