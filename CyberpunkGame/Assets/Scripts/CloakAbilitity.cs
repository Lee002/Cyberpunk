using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CloakAbilitity : MonoBehaviour
{
    private bool isCloaked = false;
    public bool playerHidden = false;
    private bool rechargingCloak;
    public float cloakTimer = 4f;
    public float cloakRechargeTimer = 10f;
    private float rechargeTimer;
    private float timer;


    [SerializeField] private SkinnedMeshRenderer material;
    [SerializeField] private Material normalShaderMaterial;
    [SerializeField] private Material cloakShaderMaterial;
    [SerializeField] private Image cloakEffect;
    [SerializeField] private GameObject recharging;
    public bool abilityInstalled = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = cloakTimer;
        rechargeTimer = cloakRechargeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(abilityInstalled)
        {
            if (Input.GetKeyDown(KeyCode.H) && !rechargingCloak)
            {
                isCloaked = true;
                FindObjectOfType<AudioManager>().Play("cloakON");
            }

            if (isCloaked)
            {
                WearCloak();
                timer -= Time.deltaTime;
                cloakEffect.fillAmount = timer / cloakTimer;
                if (timer <= 0)
                {
                    timer = cloakTimer;
                    
                    RemoveCloak();
                    FindObjectOfType<AudioManager>().Play("cloakOFF");
                    isCloaked = false;
                }
            }

            if (rechargingCloak)
            {
                recharging.SetActive(true);
                RechargeCloak();
            }
            else
            {
                recharging.SetActive(false);
            }

        }

    }

    void RemoveCloak()
    {
        Effect(false);
        playerHidden = false;
        rechargingCloak = true;

    }
    void RechargeCloak()
    {
        rechargeTimer -= Time.deltaTime;

        cloakEffect.fillAmount += Time.deltaTime / cloakRechargeTimer;
        if (rechargeTimer <= 0)
        {
            rechargingCloak = false;

            rechargeTimer = cloakRechargeTimer;
        }
    }
    void Effect(bool on)
    {
        if(on)
        {
            material.material = cloakShaderMaterial;
        }
        else
        {
            material.material = normalShaderMaterial;
        }
    }

    void WearCloak()
    {
        Effect(true);
        playerHidden = true;
    }
}
