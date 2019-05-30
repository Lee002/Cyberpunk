using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IntroManager : MonoBehaviour
{
    public AudioSource droidVoice1;
    public Animator droid;
    public List<AudioClip> droidVoices = new List<AudioClip>();
    public NavMeshAgent agent;
    public Transform pos;
    public void StartAudio()
    {
        droidVoice1.Play();
        droid.SetBool("talking", true);
        Invoke("StartAudio2", 7f);
    }
    void StartAudio2()
    {
        
        droidVoice1.clip = droidVoices[0];
        droidVoice1.Play();
        Invoke("StartAudio3", 5f);
    }

    void StartAudio3()
    {
        droidVoice1.clip = droidVoices[1];
        droidVoice1.Play();
        Invoke("StartAudio4", 6f);
    }
    void StartAudio4()
    {
        droidVoice1.clip = droidVoices[2];
        droidVoice1.Play();
    }

    void SetPosition()
    {
        agent.destination = pos.position;
    }
    void Start()
    {
        SetPosition();
        Invoke("StartAudio", 14f);
        
    }
}
