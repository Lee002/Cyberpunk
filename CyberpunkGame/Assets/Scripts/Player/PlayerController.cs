using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    [SerializeField] private Animator animator;
    [HideInInspector] public bool reachedPosition;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask layerToWalkOn;
    void Awake()
    {
        instance = this;
    }

    [HideInInspector]public PlayerMovements playerMovements;


    void Start()
    {
        playerMovements = GetComponent<PlayerMovements>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            agent.destination = GetPositionUnderCursor();

        }

        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            reachedPosition = false;
        }
        else
        {
            reachedPosition = true;
        }

        animator.SetBool("walking", reachedPosition);
    }

    Vector3 GetPositionUnderCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, layerToWalkOn);
        return hit.point;
    }
}
