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

    [SerializeField] private AudioClip goodjob;

    [SerializeField] private AudioClip bringmeOrgans;
    [SerializeField] private float timer = 3f;
    private float time;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource source2;
    [SerializeField] private TextMeshProUGUI objective;
    public GameObject finale;

    private bool bringmeorgansplayed = false;
    private bool goodjobplayed = false;

    void Start()
    {
        manager = GameManager.instance;
        time = timer;
    }

    void Update()
    {



        
        if(canCollectFromMao)
        {
            Debug.Log("PLAYING BRING ME ORGANS");
            animation.SetBool("canCollect", true);
            if (!bringmeorgansplayed)
            {
                source2.clip = bringmeOrgans;
                source2.Play();
                bringmeorgansplayed = true;
            }
            droidBringMeUi.SetActive(true);
            objective.fontStyle = FontStyles.Strikethrough;
            WaitForMao();
        }
        else
        {
            animation.SetBool("canCollect", false);
            droidBringMeUi.SetActive(false);
            time -= Time.deltaTime;
            if (time <= 0)
            {
                Debug.Log("PLAYING SOUND");
                PlaySoundEffect();
            }
            if (manager.neededMaterials.value == manager.harvestedMaterials.value)
            {
                canCollectFromMao = true;
            }
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
            if(GameManager.instance.currLevel < 4)
            {
                if (hit.transform.tag == "Droid" && dis <= 2f)
                {
                    TextMeshProUGUI text = droidBringMeUi.GetComponent<TextMeshProUGUI>();
                    text.text = "Good job! But there's still more work to be done!";
                    if (!goodjobplayed)
                    {
                        source2.clip = goodjob;
                        source2.Play();
                        goodjobplayed = true;
                    }
                    NextScene next = new NextScene();
                    StartCoroutine(next.LoadSceneNextAfterTime());
                }
            }
            else
            {
                finale.SetActive(true);
            }

        }
    }
}
