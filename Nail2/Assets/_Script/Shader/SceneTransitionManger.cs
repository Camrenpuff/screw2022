using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManger : MonoBehaviour
{
    //引用?
    public FadeScreen fadeScreen;
    public int sceneIndex;
    public Collider rugCo;

    //碰撞的情况
    private void OnTriggerEnter(Collider rugCo)
    {
        GoToScene(sceneIndex);
        print("转场");
    }

    //按钮的状况
    public void GoToSceneButton()
    {
        GoToScene(sceneIndex);
        print("转场");
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
