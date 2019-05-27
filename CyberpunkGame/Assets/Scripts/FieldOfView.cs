using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private CivilianUnit unit;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("A CIVILIAN JUST SAW YOU !!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
