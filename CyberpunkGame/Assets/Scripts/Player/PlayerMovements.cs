using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovements : MonoBehaviour
{

    [SerializeField]private NavMeshAgent agent;
    [SerializeField]private Animator animator;
    [HideInInspector] public bool reachedPosition;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void MoveToPosition(Vector3 position)
    {
        agent.destination = position;
        animator.SetBool("walking", reachedPosition);

    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(agent.remainingDistance);
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            reachedPosition = true;
        }
        else
        {
            reachedPosition = false;
        }
    }
}
