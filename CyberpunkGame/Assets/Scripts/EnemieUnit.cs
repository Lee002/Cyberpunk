using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemieUnit : MonoBehaviour
{
    private bool isPatrolling;
    public List<Transform> patrolPositions;
    [SerializeField] private float patrolTimer;
    public NavMeshAgent agent;
    void Start()
    {
        Invoke("Patrol", patrolTimer);
    }

    IEnumerator StartPatrolling()
    {
        for (int i = 0; i < patrolPositions.Count; i++)
        {
            agent.SetDestination(patrolPositions[i].position);
            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                yield return new WaitForSeconds(patrolTimer);
            }
 
        }



    }
    void Update()
    {

    }
}
