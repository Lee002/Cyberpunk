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

    [SerializeField] public Animator animator;
    [HideInInspector] public bool reachedPosition;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private LayerMask layerToWalkOn;
    [HideInInspector]public PlayerMovements playerMovements;
    public CivilianUnit selectedCivilian;
    private Vector3 previousPosition;
    private HarvestingSystem harvesting;
    public float curSpeed;
    float distance;

    void Start()
    {
        playerMovements = GetComponent<PlayerMovements>();
        harvesting = HarvestingSystem.instance;
    }

    public void StartHarvesting()
    {
        distance = Vector3.Distance(transform.position, selectedCivilian.transform.position);

        if (distance <= 4f)
        {
            player_data.State = State.Harvesting;
            transform.LookAt(selectedCivilian.transform);
            NotificationController.instance.startedHarvesting = true;
            harvesting.StartCoroutine("StartHarvesting", selectedCivilian);
        }

        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            agent.destination = GetPositionUnderCursor();
            transform.LookAt(GetPositionUnderCursor());
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
            animator.SetBool("walking", reachedPosition);
            agent.SetDestination(transform.position);
        }
        else
        {
            //Player stopped
            reachedPosition = true;
            player_data.State = State.Walking;
            animator.SetBool("walking", reachedPosition);
            animator.SetFloat("Speed", agent.remainingDistance );

        }


    }

    Vector3 GetPositionUnderCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, layerToWalkOn);
        /*if (hit.transform.tag == "Civilian")
        {
            NotificationController.instance.StartCoroutine("CantHarvestNotif");
            
            return hit.point;
        }*/
        return hit.point;
    }
}
                