using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public AudioSource droidVoice1;
    public List<AudioClip> droidVoices = new List<AudioClip>();
    public GameObject levelEndObj;

    public void StartAudio()
    {
        droidVoice1.Play();
        Invoke("StartAudio2", 2f);
    }
    void StartAudio2()
    {

        droidVoice1.clip = droidVoices[0];
        droidVoice1.Play();
        Invoke("StartAudio3", 3f);
    }

    void StartAudio3()
    {
        droidVoice1.clip = droidVoices[1];
        droidVoice1.Play();
        Invoke("StartAudio4", 3f);
    }
    void StartAudio4()
    {
        droidVoice1.clip = droidVoices[2];
        droidVoice1.Play();
        Invoke("StartAudio5", 4f);
    }
    void StartAudio5()
    {
        droidVoice1.clip = droidVoices[3];
        droidVoice1.Play();
        Invoke("StartAudio6", 2f);
    }
    void StartAudio6()
    {
        droidVoice1.clip = droidVoices[4];
        droidVoice1.Play();
        Invoke("StartFade", 4f);
    }
    void StartFade()
    {
        levelEndObj.GetComponent<NextScene>().LoadSceneNext();
    }
    void Start()
    {
        Invoke("StartAudio", 9.5f);
    }
}
