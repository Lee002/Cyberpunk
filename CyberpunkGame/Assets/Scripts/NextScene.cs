using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {
    
	void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene); // starts at 0, see File/Build Settings
    }
	
    void LoadSceneNext()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
