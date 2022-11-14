using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_EnemyAnimationTrigger : Action
{
    public EnemyGraphics enemyGraphics;
    public string triggerString;

    private bool isActionFinished;

    private void OnEnable()
    {
        isActionFinished = false;
        enemyGraphics.animator.SetTrigger(triggerString);
        isActionFinished = true;
    }

    private void OnDisable()
    {
        isActionFinished = false;
    }

    public override bool IsActionFinished()
    {
        return isActionFinished;
    }
}
