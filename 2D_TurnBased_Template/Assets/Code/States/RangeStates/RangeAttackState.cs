using UnityEngine;

public class RangeAttackState : State
{
    public float Offset;
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;

    public bool CanRangeAttackAgain;
    public bool ChangeToNewState = false;

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
        Vector3 difference = TargetARangeEnemyState.transform.position - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + Offset);

        if (CanRangeAttackAgain && !ChangeToNewState)
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

    void RestartTimerForRangeAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    public override State RunCurrentState()
    {
        if(ChangeToNewState)
        {
            TargetARangeEnemyState.TurnOffHasRangeTarget();
            GetWithinRangeAttackState.RestartDisanceFromTarget();
            Debug.Log("here");
            ChangeToNewState = false;
            return TargetARangeEnemyState;
        }
            
        if (BarricadeController.Instance.BarricadeEnabled == false && BarricadeController.Instance.CanAttackBarricade == false)
        {
            BarricadeController.Instance.CanAttackBarricade = true;//we need to make this false again somewhere
            TargetARangeEnemyState.TurnOffHasRangeTarget();
            ChangeToNewState = true;
            Debug.Log("barriacde cannot be hit anymore");
        }
        else if (TargetARangeEnemyState.CurrentRangeTarget.name == "Player")
        {
            if (TargetARangeEnemyState.CurrentRangeTarget.GetComponent<BaseCharacter>().IsCharacterDead == true)
                TargetARangeEnemyState.TurnOffHasRangeTarget();
            ChangeToNewState = true;
        }
        return this;
    }
}
