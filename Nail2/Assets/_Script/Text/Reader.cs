using ReadSpeaker;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reader : MonoBehaviour
{

    public TTSSpeaker speaker;
    public Selectable initiallySelected;
    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        TTS.Init();
        ReadText();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            TTS.InterruptAll(); 
            StopAllCoroutines();
            ReadText();
        }
    }

    void ReadText()
    {
        StartCoroutine(TextReaderCoroutine());
    }

    void ReadSelectable(Selectable selectable)
    {
        string text = "";
        if (selectable is Button)
        {
            text = selectable.GetComponentInChildren<Text>().text;
        }
        TTS.Say(text, speaker);
    }

    IEnumerator TextReaderCoroutine()
    {
        Selectable selectableToRead = initiallySelected;
        while (selectableToRead != null)
        {
            ReadSelectable(selectableToRead);
            selectableToRead.Select();
            yield return new WaitUntil(() => !speaker.audioSource.isPlaying);
            yield return new WaitForSeconds(delay);

            if(selectableToRead.navigation.selectOnRight != null)
            {
                selectableToRead = selectableToRead.navigation.selectOnRight;
            }
            else if(selectableToRead.navigation.selectOnDown!= null)
            {
                selectableToRead = selectableToRead.navigation.selectOnDown;
            }
            else
            {
                selectableToRead = null;
            }
        }
    }
}
