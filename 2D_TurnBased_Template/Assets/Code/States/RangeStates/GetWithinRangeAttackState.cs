using UnityEngine;
using UnityEngine.Rendering;

public class GetWithinRangeAttackState : State
{
    [Header("Is Within Range")]
    public bool WithinRangeAttack = false;
    public float Speed; //change this to the enemys stats later
    public float AttackRange;
    [Header("Minimun distance ti attack")]
    public float MinimunDistanceForRangeAttack;
    [Header("How far target is")]
    public float DistanceFromTarget;
    //States below
    RangeAttackState RangeAttackState;
    BaseEnemy BaseEnemy;

    private void Start()
    {
        RangeAttackState = GetComponentInChildren<RangeAttackState>();
        BaseEnemy = GetComponent<BaseEnemy>();
        //DistanceFromTarget = _maxDistanceFromTarget;
        
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, NPCController.Instance.Player.position) > AttackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, NPCController.Instance.Player.position, Speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, NPCController.Instance.Player.position) < MinimunDistanceForRangeAttack)
        {
            transform.position = Vector2.MoveTowards(transform.position, NPCController.Instance.Player.position, -Speed * Time.deltaTime);
        }
    }
    public override State RunCurrentState()
    {
        if (WithinRangeAttack)
        {
            return RangeAttackState;
        }
        return this;
    }
    //Helper functions-------------------------------------------------------->

    public void RestartDisanceFromTarget() => DistanceFromTarget = MinimunDistanceForRangeAttack;
    public void TurnOffWithinRangeBool() => WithinRangeAttack = false;
    public void TurnOnWithinRangeBool() => WithinRangeAttack = true;
}
