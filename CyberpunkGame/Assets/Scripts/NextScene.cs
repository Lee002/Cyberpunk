using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<< HEAD
public class NextScene : MonoBehaviour {

    public Animator fadeAnimator;

    public int sceneToLoad;

	void LoadScene(int scene)
=======
public class NextScene  {


    
	public void LoadScene(int scene)
>>>>>>> 46dd8a83494550c82dd5d3b6b2263f3c32c3ccdb
    {
        sceneToLoad = scene;
        fadeAnimator.SetTrigger("FadeToBlack");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad); // starts at 0, see File/Build Settings
    }
	
    public void LoadSceneNext()
<<<<<<< HEAD
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
=======
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator  LoadSceneNextAfterTime()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
>>>>>>> 46dd8a83494550c82dd5d3b6b2263f3c32c3ccdb
    }
}
