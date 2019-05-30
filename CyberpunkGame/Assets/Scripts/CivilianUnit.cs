using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianUnit : MonoBehaviour
{
    public bool harvested = false;
    [SerializeField]private Animator animation;
    [SerializeField] public GameObject blood;
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayRandomAudioSFX()
    {
        int r = Random.Range(0, clips.Count);
        source.clip = clips[r];
        source.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if(harvested)
        {
            Instantiate(blood, transform.position, Quaternion.identity);
            //harvested = false;
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
