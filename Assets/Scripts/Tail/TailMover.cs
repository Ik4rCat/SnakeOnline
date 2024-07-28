using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Mirror;

public class TailMover : NetworkBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] TailNetwork tail;

    private void Start()
    {
        transform.position = tail.Target.transform.position;
    }

    private void Update()
    {
        agent.speed = tail.Owner.Speed;
        agent.SetDestination(tail.Target.transform.position);
    }

}
