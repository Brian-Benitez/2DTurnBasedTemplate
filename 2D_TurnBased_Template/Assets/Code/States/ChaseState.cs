using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ChaseState : State
{
    [Header("States")]
    AttackState AttackState;
    TargetAEnemyState TargetAEnemyState;  

    [Header("Floats")]
    public float MovementSpeed;
    public float _distanceFromTarget;//debuging keep it public

    private void Start()
    {
        TargetAEnemyState = GetComponentInParent<TargetAEnemyState>();
        AttackState = GetComponent<AttackState>();  
    }

    private void Update()
    {
        if (_distanceFromTarget < AttackState.StoppingDistanceFromTarget)//This is where our issues lay. the _distancefromtarget needs to be reupdated to a higher number for some reason to chase someone.
            AttackState.IsWithinAttackingRange();
        else
            AttackState.NotWithinAttackingRange();

        if (AttackState.WithinRange)//gets the enemy to stop moving
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
        if (TargetAEnemyState.HaveATarget && AttackState.WithinRange)
            return AttackState;

        return this;
    }
}
