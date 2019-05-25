using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{


    #region Singleton
    public static PlayerController instance;
    [SerializeField] private Player player_data;
    void Awake()
    {
        instance = this;
        player_data = new Player();
    }
    #endregion

    [SerializeField] private Animator animator;
    [HideInInspector] public bool reachedPosition;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask layerToWalkOn;
    [HideInInspector]public PlayerMovements playerMovements;

    private Vector3 previousPosition;
    public float curSpeed;

    void Start()
    {
        playerMovements = GetComponent<PlayerMovements>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            agent.destination = GetPositionUnderCursor();
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            if(player_data.State != State.Crouched)
            {
                player_data.State = State.Crouched;

            }
            else
            {
                player_data.State = State.Idle;
            }


        }
        Animation();


    }

    private void Animation()
    {
        //animator.SetBool("walking", reachedPosition);
        if (agent.remainingDistance <= agent.stoppingDistance)
        {
            //Player walking
            reachedPosition = false;
            player_data.State = State.Idle;
            animator.SetFloat("Speed", agent.remainingDistance);
        }
        else
        {
            //Player stopped
            reachedPosition = true;
            player_data.State = State.Walking;
            
            animator.SetFloat("Speed", agent.remainingDistance );
        }


    }

    Vector3 GetPositionUnderCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, layerToWalkOn);   
        return hit.point;
    }
}
                