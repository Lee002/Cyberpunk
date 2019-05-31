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

        FindObjectOfType<AudioManager>().Play("Stab");
        civilian.harvested = true;
        Debug.Log("Starting harvest");
        PlayerController.instance.animator.SetBool("isHarvesting", true);
        //civilian.GetComponentInChildren<ProressBar>().rProgressBar.SetActive(true);
        harvestingnotification.SetActive(true);
        PlayerController.instance.transform.GetComponent<AudioSource>().Play();
        civilian.PlayRandomAudioSFX();
        GameManager.instance.harvestedMaterials.value += 25f;
        
        civilian.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(harvestingTimer);


        civilian.source.Play();
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
