using System.Collections;
using UnityEngine;

public class Action_AttackPlayer : Action
{
    public bool isDoneAttacking;
    public Rigidbody playerRB;
    public float attackForce;

    private void OnEnable()
    {
        isDoneAttacking = false;
        // attack
        Vector3 attackDirection = playerRB.position - transform.position;
        attackDirection.Normalize();

        playerRB.AddForce(attackDirection * attackForce,ForceMode.VelocityChange);
        isDoneAttacking = true;
    }

    private void OnDisable()
    {
        isDoneAttacking = false;
    }

    
    public override bool IsActionFinished()
    {
        return isDoneAttacking;
    }
}
