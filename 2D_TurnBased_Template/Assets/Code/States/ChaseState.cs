using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [Header("States")]
    AttackState AttackState;
    TargetAEnemyState TargetAEnemyState;  

    [Header("Floats")]
    public float MovementSpeed;
    public float _distanceFromTarget;//debuging keep it public

    [Header("Scripts")]
    EnemyMeleeAttack EnemyMeleeAttackRef;

    private void Start()
    {
        TargetAEnemyState = GetComponentInParent<TargetAEnemyState>();
        AttackState = GetComponent<AttackState>();  
        EnemyMeleeAttackRef = GetComponentInChildren<EnemyMeleeAttack>();
    }

    private void Update()
    {
        if(EnemyMeleeAttackRef.WithinRange)
            return;
        if(TargetAEnemyState.HaveATarget)
        {
            _distanceFromTarget = Vector2.Distance(transform.position, TargetAEnemyState.CurrentTarget.transform.position);
            Vector2 direction = TargetAEnemyState.CurrentTarget.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, TargetAEnemyState.CurrentTarget.transform.position, MovementSpeed * Time.deltaTime);
        }
    }
    public override State RunCurrentState()
    {
        if (TargetAEnemyState.HaveATarget && EnemyMeleeAttackRef.WithinRange)
            return AttackState;

        return this;
    }
}
