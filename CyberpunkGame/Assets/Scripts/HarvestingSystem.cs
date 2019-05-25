using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestingSystem : MonoBehaviour
{
    public static HarvestingSystem instance;
    void Awake()
    {
        instance = this;
    }

    [SerializeField] private float harvestingTimer;

    public IEnumerator StartHarvesting(CivilianUnit civilian)
    {
        Debug.Log("Starting harvest");
        yield return new WaitForSeconds(harvestingTimer);
        Debug.Log("You have harvested a civilian" + civilian.name);
        Destroy(civilian.gameObject);

    }

    void Update()
    {

    }
}
