using UnityEngine;

public class RangeAttackState : State
{
    public float Offset;
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;

    public bool CanRangeAttackAgain;

    TargetARangeEnemyState TargetARangeEnemyState;

    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        TargetARangeEnemyState = GetComponentInParent<TargetARangeEnemyState>();    
    }


    private void Update()
    {
        //This deals with rotating weapon below
        Vector3 difference = TargetARangeEnemyState.transform.position - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + Offset);

        if (CanRangeAttackAgain)
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
        return this;
    }
}
