using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private PlayerController player;
    public Renderer renderer;
    public Shader shader;
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
            Debug.Log(hit.transform.tag);
            if(hit.transform.tag == "Civilian")
            {
                Debug.Log("Changing " + hit.transform.name + "'s material");
                renderer = hit.transform.GetComponentInChildren< Renderer > ();
                renderer.material.shader = Shader.Find("Legacy Shaders/Self-Illumin/Diffuse");

                renderer.material.color = Color.yellow;
            }
            else
            {
                renderer.material.shader = Shader.Find("Standard");
            }
        }


    }
}
