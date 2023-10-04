using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManger : MonoBehaviour
{
    //引用?
    public FadeScreen fadeScreen;
    public int sceneIndex;



    private void OnTriggerEnter(Collider other)
    {
        GoToScene(sceneIndex);
        print("转场");
    }

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }
    // Start is called before the first frame update
    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);

        //Launch the new scene
        SceneManager.LoadScene(sceneIndex);
    }
}
