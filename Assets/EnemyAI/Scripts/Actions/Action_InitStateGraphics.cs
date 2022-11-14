using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_InitStateGraphics : Action
{
    public EnemyGraphics enemyGraphics;
    public StateController.States graphicStateToTransitionTo;

    private bool isActionFinished = true;

    private void OnEnable()
    {
        isActionFinished = false;
        enemyGraphics.ChangeGraphicState(graphicStateToTransitionTo);
        isActionFinished = true;
    }

    public override bool IsActionFinished()
    {
        return isActionFinished;
    }
}
