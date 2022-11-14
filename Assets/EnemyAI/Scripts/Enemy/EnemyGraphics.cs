using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGraphics : MonoBehaviour
{
    // this is just for showing the current state in this script's inspector
    public StateController.States currentGraphicState = StateController.States.IDLE; 

    public Animator animator;
    public Text UIText;

    public void ChangeGraphicState(StateController.States stateToTransitionTo)
    {
        currentGraphicState = stateToTransitionTo;
        UIText.text = stateToTransitionTo.ToString();
        animator.SetTrigger(stateToTransitionTo.ToString().ToLower());
    }
}
