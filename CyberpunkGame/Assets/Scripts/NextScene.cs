using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    public Animator fadeAnimator;

    public int sceneToLoad;

	void LoadScene(int scene)
    {
        sceneToLoad = scene;
        fadeAnimator.SetTrigger("FadeToBlack");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad); // starts at 0, see File/Build Settings
    }
	
    public void LoadSceneNext()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
