using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManger : MonoBehaviour
{
    //����?
    public FadeScreen fadeScreen;
    public int sceneIndex;


    //��ײ�����
    private void OnTriggerEnter(Collider other)
    {
        GoToScene(sceneIndex);
        print("ת��");
    }

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }
    

    //��ť��״��
    public void GoToSceneButton()
    {
        GoToScene(sceneIndex);
        print("ת��");
    }

    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        SceneManager.LoadScene(sceneIndex);
    }

    


}
