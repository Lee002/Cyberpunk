using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : MonoBehaviour
{

    #region Singletons
    public static NotificationController instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject cantHarvestNotif;
    public IEnumerator CantHarvestNotif()
    {
        cantHarvestNotif.SetActive(true);
        yield return new WaitForSeconds(4f);
        cantHarvestNotif.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
