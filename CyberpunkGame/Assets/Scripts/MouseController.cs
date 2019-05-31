using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private PlayerController player;
    public Renderer renderer;
    public Shader shader;
    public Material regularMaterials;
    public Material hologramMaterial;
    public Transform notification;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerController.instance;

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {

            if(hit.transform.tag == "Civilian")
            {
                Debug.Log("Changing " + hit.transform.name + "'s material");
                renderer = hit.transform.GetChild(0).GetComponentInChildren< Renderer > ();


                renderer.material.shader = hologramMaterial.shader;
                /*
                foreach (Material item in materials)
                {
                    item.shader = hologramMaterial.shader;

                    
                    item.shader = Shader.Find("Legacy Shaders/Self-Illumin/Diffuse");
                    item.color = Color.yellow;
                }*/

                notification = hit.transform.GetChild(3);
                notification.gameObject.SetActive(true);

                if(Input.GetMouseButtonDown(0))
                {
                    player.selectedCivilian = hit.transform.GetComponent<CivilianUnit>();
                    player.StartHarvesting();
                }
            }
            else
            {
                renderer.material.shader = regularMaterials.shader;
                notification.gameObject.SetActive(false);
            }
        }


    }
}
