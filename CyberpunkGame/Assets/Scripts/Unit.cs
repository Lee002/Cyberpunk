using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;

    private NavMeshAgent nav;
    private SphereCollider col;
    private Animator anim;
    
}
