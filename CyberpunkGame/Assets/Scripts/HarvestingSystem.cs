using System.Collections;
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
        civilian.harvested = true;
        Debug.Log("Starting harvest");
        PlayerController.instance.animator.SetBool("isHarvesting", true);
        civilian.GetComponentInChildren<ProressBar>().rProgressBar.SetActive(true);
        harvestingnotification.SetActive(true);
        PlayerController.instance.transform.GetComponent<AudioSource>().Play();
        GameManager.instance.harvestedMaterials.value += 25f;
        civilian.PlayRandomAudioSFX();
        civilian.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(harvestingTimer);

        Debug.Log("You have harvested a civilian" + civilian.name);
        Destroy(civilian.gameObject, 4f);
        PlayerController.instance.animator.SetBool("isHarvesting", false);
        NotificationController.instance.startedHarvesting = false;
        civilian.GetComponentInChildren<ProressBar>().rProgressBar.SetActive(false);
        PlayerController.instance.playerIsHarvesting = false;
        harvestingnotification.SetActive(false);


    }

    void Update()
    {

    }
}
