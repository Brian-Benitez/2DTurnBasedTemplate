using UnityEngine;

public class AttackState : State
{
    [Header("Melee pos")]
    public Transform MeleePos;

    [Header("Enemys attack range and T.T.A")]
    public float AttackRange;
    public float TimeBtwAttack;

    [Header("Bools Conditions to attack")]
    public bool CanHitAgain = true;
    public bool WithinRange = false;

    [Header("Layermasks for what can be hit")]
    public LayerMask WhatisHittable;
    public LayerMask BarricadeLayerMask;

    [Header("Layer Mask Indexs")]
    public int BarriacdeLayerMaskIndex = 7;

    [Header("Stopping distance for melee")]
    public float StoppingDistanceFromTarget = 1.6f;

    private EnemySwordsman EnemySwordsmanRef;
    //States ref here
    ChaseState ChaseState;
    TargetAEnemyState TargetAEnemyState;


    private float _maxTimeBtwAttacks;

    private void Start()
    {
        TargetAEnemyState = GetComponentInParent<TargetAEnemyState>();
        _maxTimeBtwAttacks = TimeBtwAttack;
        EnemySwordsmanRef = gameObject.GetComponentInParent<EnemySwordsman>();
        ChaseState = GetComponentInParent<ChaseState>();
    }

    void Update()
    {
        if (CanHitAgain && WithinRange)
        {
            Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(MeleePos.position, AttackRange, WhatisHittable);
            for (int i = 0; i < enemiesToDamges.Length; i++)
            {
                if (enemiesToDamges[i].gameObject.layer == BarriacdeLayerMaskIndex)
                {
                    BarricadeController.Instance.BarricadeTakesDamage(EnemySwordsmanRef.EnemyDamage);
                }
                else
                {
                    enemiesToDamges[i].GetComponent<BaseCharacter>().TakeDamage(EnemySwordsmanRef.EnemyDamage);
                    Debug.Log("Enemy hit " + enemiesToDamges[i].gameObject.name + "for " + EnemySwordsmanRef.EnemyDamage);
                }
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

    void RestartTimerForAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    public void IsWithinAttackingRange() => WithinRange = true;
    public void NotWithinAttackingRange() => WithinRange = false;
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(MeleePos.position, AttackRange);
    }

    public override State RunCurrentState()
    {
        if (BarricadeController.Instance.BarricadeHealth < 0)
        {
            Debug.Log("barricade is dead");
            TargetAEnemyState.TurnOffBoolHaveATarget();
            return TargetAEnemyState;
        }
        else
            return this;
    }
}
