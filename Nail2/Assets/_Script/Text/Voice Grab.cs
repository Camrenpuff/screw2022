using ReadSpeaker;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceGrab : MonoBehaviour
{
    public TTSSpeaker speaker;
    [TextArea] public String voice;

    void Speaking()
    {
        TTS.Say(voice, speaker);
    }
}

