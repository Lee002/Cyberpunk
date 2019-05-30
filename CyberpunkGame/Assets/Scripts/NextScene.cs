using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene  {


    
	public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene); // starts at 0, see File/Build Settings
    }
	
    public void LoadSceneNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator  LoadSceneNextAfterTime()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
