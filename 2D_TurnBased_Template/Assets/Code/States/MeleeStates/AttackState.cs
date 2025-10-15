using DG.Tweening;
using UnityEngine;

public class AttackState : State//rename this to EnemyAttackState
{
    [Header("Melee pos")]
    public Transform MeleePos;

    [Header("Enemys attack range and T.T.A")]
    public float AttackRange;
    public float TimeBtwAttack;
    public float WindUpTimeForMelee;

    [Header("Bools Conditions to attack")]
    public bool CanHitAgain = true;
    public bool WithinRange = false;

    [Header("Layermasks for what can be hit")]
    public LayerMask WhatisHittable;

    public bool AttackMissedPlayer = false;
    private EnemySwordsman EnemySwordsmanRef;
    //States ref here
    ChaseState ChaseState;
    EnemyWeaponRotation _enemyWeaponRotationRef;


    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        EnemySwordsmanRef = gameObject.GetComponentInParent<EnemySwordsman>();//whyd i do this?
        ChaseState = GetComponentInParent<ChaseState>();
        _enemyWeaponRotationRef = GetComponentInParent<EnemyWeaponRotation>();
    }

    void Update()
    {
        if (CanHitAgain && WithinRange)
        {
           _enemyWeaponRotationRef.IsAttacking = true;
            Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(MeleePos.position, AttackRange, WhatisHittable);

            if (enemiesToDamges.Length == 0)
            {
                Debug.Log("i hit no one:(");
                AttackMissedPlayer = true;
            }
            else
                AttackMissedPlayer = false;

            for (int i = 0; i < enemiesToDamges.Length; i++)
            {
                enemiesToDamges[i].GetComponent<BaseCharacter>().TakeDamage(EnemySwordsmanRef.EnemyDamage);
                Debug.Log("Enemy hit " + enemiesToDamges[i].gameObject.name + "for " + EnemySwordsmanRef.EnemyDamage);
            }

            RestartTimerForAttacks();
            
        }

        if (TimeBtwAttack <= 0f)
        {
            CanHitAgain = true;
            return;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
            CanHitAgain = false;
        }
    }

    public override State RunCurrentState()//this is ther issue, this should not carry on while players are still alive
    {

        if(AttackMissedPlayer == true)
        {
            //ChaseState.RestartDistance();
            _enemyWeaponRotationRef.IsAttacking = false;
            AttackMissedPlayer = false;
            return ChaseState;
        }
       
        return this;
    }

    void RestartTimerForAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;
    public void IsWithinAttackingRange() => WithinRange = true;
    public void NotWithinAttackingRange() => WithinRange = false;


    //--------------------------------------------------------------------------------------------------------------------------->
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(MeleePos.position, AttackRange);
    }

    private static void Delay(float time, System.Action _callBack)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendInterval(time).AppendCallback(() => _callBack());
    }
}
