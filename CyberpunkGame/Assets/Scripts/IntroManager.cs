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
    public GameObject levelEndObj;

    public void StartAudio()
    {
        droidVoice1.Play();
        DialogueTrigger.instance.TriggerDialogue();
        droid.SetBool("talking", true);
        Invoke("StartAudio2", 4.5f);
    }
    void StartAudio2()
    {
        droidVoice1.clip = droidVoices[0];
        DialogueManager.instance.DisplayNextSentence();
        droidVoice1.Play();
        Invoke("StartAudio3", 3f);
    }

    void StartAudio3()
    {
        droidVoice1.clip = droidVoices[1];
        DialogueManager.instance.DisplayNextSentence();
        droidVoice1.Play();
        Invoke("StartAudio4", 4f);
    }
    void StartAudio4()
    {
        droidVoice1.clip = droidVoices[2];
        DialogueManager.instance.DisplayNextSentence();
        droidVoice1.Play();
        Invoke("StopTalk", 3f);
    }

    void StopTalk()
    {
        droid.SetBool("talking", false);
        Invoke("StartFade", 4f);
    }

    void StartFade()
    {
        levelEndObj.GetComponent<NextScene>().LoadScene(2);
    }

    void SetPosition()
    {
        agent.destination = pos.position;
    }
    void Start()
    {
        SetPosition();
        Invoke("StartAudio", 7f);
        
    }
}
