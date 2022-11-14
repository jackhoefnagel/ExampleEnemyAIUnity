using UnityEngine;
using UnityEngine.AI;

public class Action_NavmeshDestination : Action
{
    public NavMeshAgent navMeshAgent;
    public Transform destinationTransform;
    public Transform myTransform;
    public bool isContinuousDestination = false;
    public float destinationRangeMargin = 0.5f;

    private bool hasReachedDestination = false;

    private void OnEnable()
    {
        if (myTransform == null) myTransform = transform;
        navMeshAgent.isStopped = false;
        hasReachedDestination = false;
        navMeshAgent.SetDestination(destinationTransform.position);
    }

    private void OnDisable()
    {
        navMeshAgent.isStopped = true;
        hasReachedDestination = false;
    }

    private void Update()
    {
        if (isContinuousDestination)
        {
            navMeshAgent.SetDestination(destinationTransform.position);
        }

        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance + destinationRangeMargin)
        {
            hasReachedDestination = true;
        }
    }

    public override bool IsActionFinished()
    {
        return hasReachedDestination;
    }
}
