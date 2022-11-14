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

    public List<StateNavmeshAgentSettings> stateNavmeshAgentSettings;

    public void SetNavmeshAgentSettingsByState(StateController.States state)
    {
        StateNavmeshAgentSettings settings = stateNavmeshAgentSettings.Find(x => x.state == state);
        float newStoppingDistance = settings.stoppingDistance;
        float newSpeed = settings.speed;
        navMeshAgent.stoppingDistance = newStoppingDistance;
        navMeshAgent.speed = newSpeed;
    }
}
