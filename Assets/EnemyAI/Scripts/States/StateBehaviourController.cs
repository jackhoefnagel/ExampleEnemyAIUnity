using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StateStateBehaviour
{
    public StateController.States state;
    public StateBehaviour stateBehaviour;
}

public class StateBehaviourController : MonoBehaviour
{
    public List<StateStateBehaviour> stateStateBehaviours;

    public void ActivateStateBehaviourByState(StateController.States state)
    {
        for (int i = 0; i < stateStateBehaviours.Count; i++)
        {
            stateStateBehaviours[i].stateBehaviour.gameObject?.SetActive(false);
        }

        GetStateBehaviourByState(state).gameObject?.SetActive(true);
    }

    public StateBehaviour GetStateBehaviourByState(StateController.States stateReference)
    {
        return stateStateBehaviours.Find(x => x.state == stateReference).stateBehaviour;
    }
}
