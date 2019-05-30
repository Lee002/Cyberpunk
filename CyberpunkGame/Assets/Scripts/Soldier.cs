using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Soldier : MonoBehaviour
{
    private Animator _animator;

    public NavMeshAgent _navMeshAgent;

    public GameObject Player;

    public float AttackDistance = 10.0f;

    public float FollowDistance = 20.0f;

    [Range(0.0f, 1.0f)]
    public float AttackProbability = 0.5f;

    [Range(0.0f, 1.0f)]
    public float HitAccuracy = 0.5f;

    public float DamagePoints = 2.0f;

    public AudioSource playerSeen;

    public Transform[] patrolPoints;

    private int currentControlPointIndex = 0;

    private bool patrol = true;

    protected void Awake()
    {
      
       // _navMeshAgent = GetComponent<NavMeshAgent>();

        //_animator = GetComponent<Animator>();

        MoveToNextPatrolPoint();

    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.enabled)
        {
            /*float dist = Vector3.Distance(Player.transform.position, this.transform.position);

            bool shoot = false;
            patrol = false;
            bool follow = (dist < FollowDistance);

            if (follow)
            {
                float random = Random.Range(0.0f, 1.0f);
                if (random > (1.0f - AttackProbability) && dist < AttackDistance)
                {
                    shoot = true;
                }

                _navMeshAgent.SetDestination(Player.transform.position);
            }

            patrol = !follow && !shoot && patrolPoints.Length > 0;

            if ((!follow || shoot) && !patrol)
                _navMeshAgent.SetDestination(transform.position);
            */
            // Patrolling between points if there are patrol points
            if (patrol)
            {
                if (!_navMeshAgent.pathPending && 
                    _navMeshAgent.remainingDistance < 0.5f)
                    MoveToNextPatrolPoint();
            }

            /*_animator.SetBool("Shoot", shoot);
            _animator.SetBool("Run", follow || patrol);*/

            // TODO: Add a walk animation for patrol

        }
    }


    void MoveToNextPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            _navMeshAgent.destination = patrolPoints[currentControlPointIndex].position;

            currentControlPointIndex++;
            currentControlPointIndex %= patrolPoints.Length;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            patrol = false;
            _navMeshAgent.destination = transform.position;
            transform.LookAt(Player.transform);
            playerSeen.Play();
            GameManager.instance.GameOver();
            Debug.Log("WOW SOMEONE HERE");
        }
    }

}
