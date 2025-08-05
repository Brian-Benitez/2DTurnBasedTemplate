using UnityEngine;

public class ChaseState : State
{
    public AttackState AttackState;

    public EnemyMeleeAttack EnemyMeleeAttackRef;
    public override State RunCurrentState()
    {
        return this;
    }
}
