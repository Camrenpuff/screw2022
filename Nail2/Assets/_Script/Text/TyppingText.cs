

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class typpingText : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] TMP_Text textComponent;
    string writer;
    [SerializeField] private Coroutine coroutine;

    [SerializeField] float delayBeforeStart = 0f;
    [SerializeField] float timeBtwChars = 0.1f;
    [SerializeField] string leadingChar = "";
    [SerializeField] bool leadingCharBeforeDelay = false;
    [Space(10)][SerializeField] private bool startOnEnable = false;

    [Header("Collision-Based")]
    [SerializeField] private bool clearAtStart = false;
    [SerializeField] private bool startOnCollision = false;
    enum options { clear, complete }
    [SerializeField] options collisionExitOptions;

    // Use this for initialization
    void Awake()
    {
        if (text != null)
        {
            writer = text.text;
        }

        if (textComponent != null)
        {
            writer = textComponent.text;
        }
    }

    void Start()
    {
        if (!clearAtStart) return;
        if (text != null)
        {
            text.text = "";
        }

        if (textComponent != null)
        {
            textComponent.text = "";
        }
    }

    private void OnEnable()
    {
        print("On Enable!");
        if (startOnEnable) StartTypewriter();
    }

    private void OnTriggerEnter(Collider col)
    {
        print("Collision!");
        if (startOnCollision)
        {
            StartTypewriter();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (collisionExitOptions == options.complete)
        {
            if (text != null)
            {
                text.text = writer;
            }

            if (textComponent != null)
            {
                textComponent.text = writer;
            }
        }
        // clear
        else
        {
            if (text != null)
            {
                text.text = "";
            }

            if (textComponent != null)
            {
                textComponent.text = "";
            }
        }

        StopAllCoroutines();
    }


    private void StartTypewriter()
    {
        StopAllCoroutines();

        if (text != null)
        {
            text.text = "";

            StartCoroutine("TypeWriterText");
        }

        if (textComponent != null)
        {
            textComponent.text = "";

            StartCoroutine("TypeWriterTMP");
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator TypeWriterText()
    {
        text.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (text.text.Length > 0)
            {
                text.text = text.text.Substring(0, text.text.Length - leadingChar.Length);
            }
            text.text += c;
            text.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            text.text = text.text.Substring(0, text.text.Length - leadingChar.Length);
        }

        yield return null;
    }

    IEnumerator TypeWriterTMP()
    {
        textComponent.text = leadingCharBeforeDelay ? leadingChar : "";

        yield return new WaitForSeconds(delayBeforeStart);

        foreach (char c in writer)
        {
            if (textComponent.text.Length > 0)
            {
                textComponent.text = textComponent.text.Substring(0, textComponent.text.Length - leadingChar.Length);
            }
            textComponent.text += c;
            textComponent.text += leadingChar;
            yield return new WaitForSeconds(timeBtwChars);
        }

        if (leadingChar != "")
        {
            textComponent.text = textComponent.text.Substring(0, textComponent.text.Length - leadingChar.Length);
        }
    }
}
