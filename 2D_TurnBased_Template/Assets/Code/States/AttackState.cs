using UnityEngine;

public class AttackState : State
{
    TargetAEnemyState TargetAEnemyState;

    private void Start()
    {
        TargetAEnemyState = GetComponent<TargetAEnemyState>();
    }
    public override State RunCurrentState()
    {
        return this;
    }
}
