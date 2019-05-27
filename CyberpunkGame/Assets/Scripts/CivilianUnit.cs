using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianUnit : MonoBehaviour
{
    public bool harvested = false;
    [SerializeField]private Animator animation;
    [SerializeField] private GameObject blood;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(harvested)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
        }
        animation.SetBool("harvested", harvested);
        Ray ray = new Ray(transform.position, Vector3.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "Player")
            {
                Debug.Log("Hit " + hit.transform.name);

            }
        }
    }
}
