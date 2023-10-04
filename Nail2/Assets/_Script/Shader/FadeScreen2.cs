using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen2 : MonoBehaviour
{
    public bool FadeOnStart = true;
    public float fadeDuration = 2f;
    //public Color fadeColor;
    //private Renderer rend;
    public CanvasGroup fadeCanvas;
    public float alphaF;



    void Start()
    {
        //rend = GetComponent<Renderer>();
        alphaF = fadeCanvas.alpha;
        if (FadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        Fade(1, 0);
        fadeCanvas.interactable= true;
        fadeCanvas.blocksRaycasts= true;
        //Invoke("NotRender", fadeDuration + 1f);
    }

    public void FadeOut()
    {
        Fade(0, 1);

    }

    //private void NotRender()
    //{
    //    fadeCanvas.enabled = false;
    //}

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }


    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            //Color newColor = fadeColor;
            fadeCanvas.alpha = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            //rend.material.SetColor("_Color", newColor);

            timer += Time.deltaTime;
            yield return null;
        }


        //Color newColor2 = fadeColor;
        //newColor2.a = alphaOut;

        //rend.material.SetColor("_Color", newColor2);
    }
}
