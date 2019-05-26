using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProressBar : MonoBehaviour
{
    public GameObject rProgressBar;
    public Transform loadingBar;
    public Transform textIndicator;
    [SerializeField] private float currAmount;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Awake()
    {
        currAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (currAmount < 100)
        {
            currAmount += speed * Time.deltaTime;
        }
        loadingBar.GetComponent<Image>().fillAmount = currAmount / 100;

    }
}
