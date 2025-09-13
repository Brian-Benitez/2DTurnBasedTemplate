using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [Header("States")]
    AttackState AttackState;
    TargetAEnemyState TargetAEnemyState;  

    [Header("Floats")]
    public float MovementSpeed;
    public float DistanceFromTarget;

    private void Start()
    {
        TargetAEnemyState = GetComponentInParent<TargetAEnemyState>();
        AttackState = GetComponent<AttackState>();  
    }

    private void Update()
    {
        if (DistanceFromTarget < AttackState.StoppingDistanceFromTarget)
            AttackState.IsWithinAttackingRange();
        else
            AttackState.NotWithinAttackingRange();

        if (AttackState.WithinRange)//gets the enemy to stop moving
            return;
        if(TargetAEnemyState.HaveATarget)
        {
            DistanceFromTarget = Vector2.Distance(transform.position, TargetAEnemyState.CurrentTarget.transform.position);
            Vector2 direction = TargetAEnemyState.CurrentTarget.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, TargetAEnemyState.CurrentTarget.transform.position, MovementSpeed * Time.deltaTime);
        }

    }

    public void RestartDistance() => DistanceFromTarget = 6f;
    public override State RunCurrentState()
    {
        if (TargetAEnemyState.HaveATarget && AttackState.WithinRange)
            return AttackState;

        return this;
    }
}
