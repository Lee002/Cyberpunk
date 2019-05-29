using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIController : MonoBehaviour
{
    private GameManager manager;
    [SerializeField] private Image harvestProgressBar;
    public TextMeshProUGUI text;
    private void Start()
    {
        manager = GameManager.instance;
    }

    void Update()
    {
        harvestProgressBar.fillAmount = manager.harvestedMaterials.value / manager.neededMaterials.value;
        text.text = "Harvested: " + (manager.harvestedMaterials.value * 100f) / manager.neededMaterials.value + "%"; 
    }
}
