using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DroidController : MonoBehaviour
{
    public bool canCollectFromMao;
    private GameManager manager;
    [SerializeField] private Animator animation;
    [SerializeField] private GameObject droidBringMeUi;
    [SerializeField] List<AudioClip> sfxs;
    [SerializeField] private float timer = 3f;
    private float time;
    [SerializeField] private AudioSource source;
    [SerializeField] private TextMeshProUGUI objective;
    void Start()
    {
        manager = GameManager.instance;
        time = timer;
    }

    void Update()
    {

        time -= Time.deltaTime;
        if(time <= 0)
        {
            PlaySoundEffect();
        }
        if(manager.neededMaterials.value == manager.harvestedMaterials.value)
        {
            canCollectFromMao = true;
        }

        
        if(canCollectFromMao)
        {
            animation.SetBool("canCollect", true);
            droidBringMeUi.SetActive(true);
            objective.fontStyle = FontStyles.Strikethrough;
            WaitForMao();
        }
        else
        {
            animation.SetBool("canCollect", false);
            droidBringMeUi.SetActive(false);

        }
    }
    void PlaySoundEffect()
    {
        int random = Random.Range(0, sfxs.Count);
        source.clip = sfxs[random];
        source.Play();
        time = timer;
    }
    void WaitForMao()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float dis = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        if (Physics.Raycast(ray, out hit)) 
        {
            
            if(hit.transform.tag == "Droid" && dis <= 2f)
            {
                TextMeshProUGUI text = droidBringMeUi.GetComponent<TextMeshProUGUI>();
                text.text = "You did very well! You still have a long way to go!";
                NextScene next = new NextScene();
                StartCoroutine(next.LoadSceneNextAfterTime());
            }
        }
    }
}
