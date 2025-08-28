using UnityEngine;

public class GetWithinRangeAttackState : State
{
    [Header("Is Within Range")]
    public bool WithinRangeAttack = false;
    [Header("Stopping distance from enemy")]
    public float StoppingDistanceForRangeAttack;
    [Header("How far target is")]
    public float DistanceFromTarget = 15f;
    float _maxDistanceFromTarget;
    //States below
    RangeAttackState RangeAttackState;
    TargetARangeEnemyState TargetARangeEnemyState;
    BaseEnemy BaseEnemy;

    private void Start()
    {
        RangeAttackState = GetComponentInChildren<RangeAttackState>();
        TargetARangeEnemyState = GetComponent<TargetARangeEnemyState>();
        BaseEnemy = GetComponent<BaseEnemy>();
        _maxDistanceFromTarget = DistanceFromTarget;
    }

    private void Update()
    {
        if (DistanceFromTarget > StoppingDistanceForRangeAttack)
        {
            TurnOffWithinRangeBool();
            DistanceFromTarget = Vector2.Distance(transform.position, TargetARangeEnemyState.CurrentRangeTarget.transform.position);
            Vector2 direction = TargetARangeEnemyState.CurrentRangeTarget.transform.position - transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, TargetARangeEnemyState.CurrentRangeTarget.transform.position, BaseEnemy.EnemySpeed * Time.deltaTime);
            Debug.Log("loooooo");
        }
        else if(DistanceFromTarget < StoppingDistanceForRangeAttack)
        {
            TurnOnWithinRangeBool();
            return;
        }
            
    }
    public override State RunCurrentState()
    {
        if (WithinRangeAttack)
        {
            Debug.Log("we here");
            return RangeAttackState;
        }
        Debug.Log("what " + this);    
        return this;
    }
    //Helper functions-------------------------------------------------------->

    public void RestartDisanceFromTarget() => DistanceFromTarget = _maxDistanceFromTarget;
    public void TurnOffWithinRangeBool() => WithinRangeAttack = false;
    public void TurnOnWithinRangeBool() => WithinRangeAttack = true;
}
