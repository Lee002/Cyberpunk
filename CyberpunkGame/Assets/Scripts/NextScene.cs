using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<< HEAD
public class NextScene  {


    
	public void LoadScene(int scene)
=======

public class NextScene : MonoBehaviour {

    public Animator fadeAnimator;

    public int sceneToLoad;

	public void LoadScene(int scene)

    {
        sceneToLoad = scene;
        fadeAnimator.SetTrigger("FadeToBlack");
    }

    public void OnFadeComplete()
>>>>>>> parent of a364d89... Revert "fix"
    {
        SceneManager.LoadScene(scene); // starts at 0, see File/Build Settings
    }
	
    public void LoadSceneNext()
    {
<<<<<<< HEAD
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
=======
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
>>>>>>> parent of a364d89... Revert "fix"
    }

    public IEnumerator  LoadSceneNextAfterTime()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
