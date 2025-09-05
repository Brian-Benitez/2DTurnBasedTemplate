using UnityEngine;
using UnityEngine.Rendering;

public class GetWithinRangeAttackState : State
{
    [Header("Is Within Range")]
    public bool WithinRangeAttack = false;
    [Header("Stopping distance from enemy")]
    public float StoppingDistanceForRangeAttack;
    [Header("How far target is")]
    public float DistanceFromTarget;
    //States below
    RangeAttackState RangeAttackState;
    TargetARangeEnemyState TargetARangeEnemyState;
    BaseEnemy BaseEnemy;

    private void Start()
    {
        RangeAttackState = GetComponentInChildren<RangeAttackState>();
        TargetARangeEnemyState = GetComponent<TargetARangeEnemyState>();
        BaseEnemy = GetComponent<BaseEnemy>();
        //DistanceFromTarget = _maxDistanceFromTarget;
        
    }

    private void Update()
    {
        DistanceFromTarget = Vector2.Distance(transform.position, TargetARangeEnemyState.CurrentRangeTarget.transform.position);//check to see if we have it yet

        if (WithinRangeAttack)
            return;

        if (TargetARangeEnemyState.HasRangeTarget && DistanceFromTarget > StoppingDistanceForRangeAttack)//check this later
        {
            Vector2 direction = TargetARangeEnemyState.CurrentRangeTarget.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, TargetARangeEnemyState.CurrentRangeTarget.transform.position, BaseEnemy.EnemySpeed * Time.deltaTime);
            Debug.Log("runnuing to target");
            TurnOffWithinRangeBool();
        }
        else
        {
            TurnOnWithinRangeBool();
        }
            
            
    }
    public override State RunCurrentState()
    {
        if (WithinRangeAttack && TargetARangeEnemyState.HasRangeTarget)
        {
            return RangeAttackState;
        }
        return this;
    }
    //Helper functions-------------------------------------------------------->

    public void RestartDisanceFromTarget() => DistanceFromTarget = StoppingDistanceForRangeAttack;
    public void TurnOffWithinRangeBool() => WithinRangeAttack = false;
    public void TurnOnWithinRangeBool() => WithinRangeAttack = true;
}
