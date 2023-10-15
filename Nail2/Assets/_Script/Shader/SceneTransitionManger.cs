using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManger : MonoBehaviour
{
    //����?
    public FadeScreen fadeScreen;
    public int sceneIndex;
    public Collider rugCo;

    //��ײ�����
    private void OnTriggerEnter(Collider rugCo)
    {
        GoToScene(sceneIndex);
        print("ת��");
    }

    //��ť��״��
    public void GoToSceneButton()
    {
        GoToScene(sceneIndex);
        print("ת��");
    }

   






    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }
    
    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        SceneManager.LoadScene(sceneIndex);
    }

    


}
