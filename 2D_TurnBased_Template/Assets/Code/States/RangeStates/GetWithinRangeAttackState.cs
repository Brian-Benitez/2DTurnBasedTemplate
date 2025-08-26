using UnityEngine;

public class GetWithinRangeAttackState : State
{
    [Header("Is Within Range")]
    public bool WithinRangeAttack = false;
    [Header("Stopping distance from enemy")]
    public float StoppingDistanceForRangeAttack;
    [Header("How far target is")]
    public float DistanceFromTarget;
    float _maxDistanceFromTarget;
    //States below
    RangeAttackState RangeAttackState;
    TargetARangeEnemyState TargetARangeEnemyState;
    BaseEnemy BaseEnemy;

    private void Start()
    {
        RangeAttackState = GetComponent<RangeAttackState>();
        TargetARangeEnemyState = GetComponent<TargetARangeEnemyState>();
        BaseEnemy = GetComponent<BaseEnemy>();
        _maxDistanceFromTarget = DistanceFromTarget;
    }

    private void Update()
    {
        if(WithinRangeAttack)
            return;
        if (DistanceFromTarget > StoppingDistanceForRangeAttack)
        {
            TurnOffWithinRangeBool();
            DistanceFromTarget = Vector2.Distance(transform.position, TargetARangeEnemyState.CurrentRangeTarget.transform.position);
            Vector2 direction = TargetARangeEnemyState.CurrentRangeTarget.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, TargetARangeEnemyState.CurrentRangeTarget.transform.position, BaseEnemy.EnemySpeed * Time.deltaTime);
        }
        else
            TurnOnWithinRangeBool();
    }
    public override State RunCurrentState()
    {
        if (WithinRangeAttack)
            return RangeAttackState;
        return this;
    }
    //Helper functions-------------------------------------------------------->

    public void RestartDisanceFromTarget() => DistanceFromTarget = _maxDistanceFromTarget;
    public void TurnOffWithinRangeBool() => WithinRangeAttack = false;
    public void TurnOnWithinRangeBool() => WithinRangeAttack = true;
}
