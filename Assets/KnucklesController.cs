using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KnucklesController : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent navMeshAgent;

    void Start()
    {
        
    }

    void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
