using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RichText1 : MonoBehaviour


{
    [SerializeField] private TMP_Text textComponent;
    [SerializeField] private string frontSentence;
    [SerializeField] private bool hasHightWord;
    [SerializeField] private string keyWords;
    [SerializeField] private bool startOnCollision = false;
    //LinkedList<TMP_Text> textList;
    public GameObject T_KeyWords;
    




    private void Start()
    {
        #region Instantiate
        //GameObject obj1 = GameObject.Instantiate(T_KeyWords);
        //TextMeshPro TMP = obj1.GetComponent<TextMeshPro>();
        //TMP_Text highlightWord = TMP;
        //highlightWord.text = keyWords;
        #endregion

        //声明初始透明度
        float tAlpha = 0f;
        string outputString = frontSentence;
        
        StopAllCoroutines();

        if (hasHightWord)
        {
            outputString += $" <color=green>{keyWords}</color>";
            
        }
        
        textComponent.text = outputString;

        textComponent.alpha = tAlpha;

    }

    private void OnTriggerEnter(Collider col)
    {
        print("Collision!");
        if (startOnCollision)
        {
           
            StartCoroutine("ShowUp");
           
        }
    }



    IEnumerator ShowUp()
    {
        for (float tAlpha = 0f; tAlpha <= 1; tAlpha += 0.01f)
        {
            textComponent.alpha = tAlpha;

            yield return null;

        }

    }

    void Update()
    {
        textComponent.ForceMeshUpdate();
        var textInfo = textComponent.textInfo;

        for (int i = 0;i <textInfo.characterCount;i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.5f) * 0.2f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length;++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices =meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh,i);
        }


        
    }
}
