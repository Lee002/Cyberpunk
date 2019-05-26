﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingSystem : MonoBehaviour
{
    public static HarvestingSystem instance;
    public GameObject harvestingnotification;
    void Awake()
    {
        instance = this;
    }

    [SerializeField] private float harvestingTimer;

    public IEnumerator StartHarvesting(CivilianUnit civilian)
    {
        Debug.Log("Starting harvest");
        PlayerController.instance.animator.SetBool("isHarvesting", true);
        civilian.GetComponentInChildren<ProressBar>().rProgressBar.SetActive(true);
        harvestingnotification.SetActive(true);
        yield return new WaitForSeconds(harvestingTimer);
        Debug.Log("You have harvested a civilian" + civilian.name);
        Destroy(civilian.gameObject);
        PlayerController.instance.animator.SetBool("isHarvesting", false);
        NotificationController.instance.startedHarvesting = false;
        civilian.GetComponent<ProressBar>().rProgressBar.SetActive(false);
        harvestingnotification.SetActive(false);
    }

    void Update()
    {

    }
}
