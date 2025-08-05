using UnityEngine;

public class AttackState : State
{
    public TargetAEnemyState TargetAEnemyState;
    public override State RunCurrentState()
    {
        return this;
    }
}
