using UnityEngine;

public class ChaseState : State
{
    public AttackState AttackState;

    public EnemyMeleeAttack EnemyMeleeAttackRef;
    public TargetAEnemyState TargetAEnemyStateRef;
    public override State RunCurrentState()
    {
        return this;
    }
}
