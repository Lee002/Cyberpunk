using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiPlayButton : MonoBehaviour
{
    private bool Clicked = false;

    public GameObject NextSceneObj;

    // Start is called before the first frame update
    void Start()
    {
        if (!Clicked)
        {
            Button b = GetComponent<Button>();
            AudioSource audio = GetComponent<AudioSource>();
            b.onClick.AddListener(delegate ()
            {
                audio.Play();
                NextSceneObj.GetComponent<NextScene>().LoadSceneNext();
                Clicked = true;
            });
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
