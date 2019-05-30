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
    public CloakAbilitity abilitity;
    void Start()
    {
        harvestedMaterials.value = 0f;
        switch (currLevel)
        {
            case 1:
                neededMaterials.value = 50f;
                FindObjectOfType<AudioManager>().Play("Level1");
                break;
            case 2:
                neededMaterials.value = 100f;
                FindObjectOfType<AudioManager>().Play("Level2");
                break;
            case 3:
                neededMaterials.value = 200f;
                FindObjectOfType<AudioManager>().Play("Level2");
                break;
            case 4:
                neededMaterials.value = 250f;
                FindObjectOfType<AudioManager>().Play("Level2");
                abilitity.abilityInstalled = true;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
