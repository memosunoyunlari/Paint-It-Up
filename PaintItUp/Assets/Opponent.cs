using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Opponent : MonoBehaviour
{
    NavMeshAgent navAgent;
    [SerializeField] Transform finishLine;
    
    private void Start()
    {

        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = finishLine.position;

    }
}
