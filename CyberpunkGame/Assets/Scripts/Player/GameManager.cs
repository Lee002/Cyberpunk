using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    void Awake()
    {

        instance = this;
    }
    public FloatDataAsset neededMaterials;
    public FloatDataAsset harvestedMaterials;

    public int currLevel;
    public GameObject gameOverScreen;

    void Start()
    {
        harvestedMaterials.value = 0f;
        switch (currLevel)
        {
            case 1:
                neededMaterials.value = 50f;

                break;
            case 2:
                neededMaterials.value = 100f;
                FindObjectOfType<AudioManager>().Play("Level2");
                break;

            default:
                break;
        }
    }


    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Invoke("RestartLevel", 3f);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currLevel);
    }
}
