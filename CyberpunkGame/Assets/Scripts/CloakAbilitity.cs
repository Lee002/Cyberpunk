using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        timer = cloakTimer;
        rechargeTimer = cloakRechargeTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H) && !rechargingCloak )
        {
            isCloaked = true;
        }

        if(isCloaked )
        {
            WearCloak();
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                timer = cloakTimer;
                RemoveCloak();

                isCloaked = false;
            }
        }

        if(rechargingCloak)
        {
            RechargeCloak();
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
        if(rechargeTimer <= 0)
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
