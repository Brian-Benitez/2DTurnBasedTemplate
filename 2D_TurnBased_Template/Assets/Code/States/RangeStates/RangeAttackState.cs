using UnityEngine;

public class RangeAttackState : State
{
    public float Offset;
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;

    public bool CanRangeAttackAgain;
    public bool IsAttacking = false;
    public bool IsStillWithinRange = false;

    TargetARangeEnemyState TargetARangeEnemyState;
    GetWithinRangeAttackState GetWithinRangeAttackState;

    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        TargetARangeEnemyState = GetComponentInParent<TargetARangeEnemyState>();    
        GetWithinRangeAttackState = GetComponentInParent<GetWithinRangeAttackState>();
    }


    private void Update()
    {
        //This deals with rotating weapon below

        Vector3 lookat = transform.InverseTransformPoint(TargetARangeEnemyState.CurrentRangeTarget.transform.position);
        float angle = Mathf.Atan2(lookat.y, lookat.x) * Mathf.Rad2Deg - 90;
        transform.Rotate(0, 0, angle);

        if (GetWithinRangeAttackState.DistanceFromTarget < GetWithinRangeAttackState.StoppingDistanceForRangeAttack)
        {
            IsStillWithinRange = true;
            if (CanRangeAttackAgain)//check if the distance hits the minium then attack here
            {
                Instantiate(Projectile, ShotPoint.position, transform.rotation);
                RestartTimerForRangeAttacks();
            }

            if (TimeBtwAttack <= 0)
            {
                CanRangeAttackAgain = true;
                return;
            }
            else
            {
                TimeBtwAttack -= Time.deltaTime;
                CanRangeAttackAgain = false;
            }
        }
        else
            IsStillWithinRange = false;

    }

    void RestartTimerForRangeAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    public override State RunCurrentState()
    {
        if (!IsStillWithinRange)
        {
            Debug.Log("get back ti within range!");
            GetWithinRangeAttackState.TurnOffWithinRangeBool();
            return GetWithinRangeAttackState;
        }
        if (!IsAttacking)
        {
            GetWithinRangeAttackState.TurnOffWithinRangeBool();
            TargetARangeEnemyState.TurnOffHasRangeTarget();
            //GetWithinRangeAttackState.RestartDisanceFromTarget();
            return TargetARangeEnemyState;
        }


        if (BarricadeController.Instance.BarricadeEnabled == false && BarricadeController.Instance.CanAttackBarricade == false)
        {
            BarricadeController.Instance.CanAttackBarricade = true;//we need to make this false again somewhere
            TargetARangeEnemyState.TurnOffHasRangeTarget();
            IsAttacking = false;
            Debug.Log("barriacde cannot be hit anymore and " + IsAttacking);
        }
        else if (TargetARangeEnemyState.CurrentRangeTarget.name == "Player")
        {
            if (TargetARangeEnemyState.CurrentRangeTarget.GetComponent<BaseCharacter>().IsCharacterDead == true)
                TargetARangeEnemyState.TurnOffHasRangeTarget();
            IsAttacking = false;
        }
        else
        {
            IsAttacking = true;
            Debug.Log("still attaking "+ IsAttacking);
        }

            return this;
    }
}
