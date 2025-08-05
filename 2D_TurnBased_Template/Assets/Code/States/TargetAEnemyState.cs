using UnityEngine;

public class TargetAEnemyState : State
{
    public ChaseState ChaseState;
    public override State RunCurrentState()
    {   
        return this;
    }

    private int PickAEnemyIndex()
    {
       return Random.Range(0, 10);
    }

}
