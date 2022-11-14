using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public StateBehaviourController stateBehaviourController;

    public EnemyGraphics enemyGraphics;
    public EnemyMovement enemyMovement;
    public Transform playerTransform;

    public enum States { IDLE, ALERT, CHASE, ATTACK }
    public States currentState = States.IDLE;

    private void Start()
    {
        stateBehaviourController.ActivateStateBehaviourByState(currentState);
    }

    public void SetCurrentState(States newState)
    {
        if (newState != currentState)
        {
            currentState = newState;
            stateBehaviourController.ActivateStateBehaviourByState(newState);
        }
    }


    // Currently only used for UI Button purposes
    public void SetCurrentStateByString(string newStateString)
    {
        switch (newStateString)
        {
            case "idle":
                SetCurrentState(States.IDLE);
                break;
            case "alert":
                SetCurrentState(States.ALERT);
                break;
            case "chase":
                SetCurrentState(States.CHASE);
                break;
            case "attack":
                SetCurrentState(States.ATTACK);
                break;
            default:
                SetCurrentState(States.IDLE);
                break;
        }

        
    }

}
