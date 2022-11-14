using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
public class StateNavmeshAgentSettings
{
    public StateController.States state;
    public float stoppingDistance;
    public float speed;
}


public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    private Transform navDestinationTransform;

    public List<StateNavmeshAgentSettings> stateNavmeshAgentSettings;

    private bool continuousFollow = false;

    private void Update()
    {
        if (continuousFollow && navDestinationTransform != null)
        {
            // perhaps build in a timer so that the destination is not set every frame
            navMeshAgent.SetDestination(navDestinationTransform.position);
        }
    }


    public void SetNavmeshAgentSettingsByState(StateController.States state)
    {
        StateNavmeshAgentSettings settings = stateNavmeshAgentSettings.Find(x => x.state == state);
        float newStoppingDistance = settings.stoppingDistance;
        float newSpeed = settings.speed;
        navMeshAgent.stoppingDistance = newStoppingDistance;
        navMeshAgent.speed = newSpeed;
    }

    public void MoveToTransformDestination(bool continuous, Transform targetTransform)
    {
        if (continuous)
        {
            continuousFollow = true;
            navDestinationTransform = targetTransform;
            navMeshAgent.isStopped = false;
        }
        else
        {
            navMeshAgent.isStopped = false;
            continuousFollow = false;
            navMeshAgent.SetDestination(targetTransform.position);
        }
    }

    public void StopAllMovement()
    {
        Debug.Log("Stop is called");
        continuousFollow = false;
        navMeshAgent.isStopped = true;
    }
}
