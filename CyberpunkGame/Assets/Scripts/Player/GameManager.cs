using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                break;

            default:
                break;
        }
    }
}
