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
    void Start()
    {
        manager = GameManager.instance;
    }

    void Update()
    {
        if(manager.neededMaterials.value == manager.harvestedMaterials.value)
        {
            canCollectFromMao = true;
        }

        
        if(canCollectFromMao)
        {
            animation.SetBool("canCollect", true);
            droidBringMeUi.SetActive(true);

            WaitForMao();
        }
        else
        {
            animation.SetBool("canCollect", false);
            droidBringMeUi.SetActive(false);

        }
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
