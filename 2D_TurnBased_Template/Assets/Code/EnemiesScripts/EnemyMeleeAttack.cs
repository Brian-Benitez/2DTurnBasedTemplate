using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMeleeAttack : MonoBehaviour
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

    private EnemySwordsman EnemySwordsmanRef;
    private MovementForEnemy MovementForEnemyRef;
    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        EnemySwordsmanRef = gameObject.GetComponentInParent<EnemySwordsman>();
        MovementForEnemyRef = gameObject.GetComponentInParent<MovementForEnemy>();
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Barricade") || collision.CompareTag("NPC"))
            WithinRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision) => WithinRange = false;
    */


    void Update()
    {
        if(MovementForEnemyRef._distanceFromTarget < 1.6f)//this is ugly but it works need to update/ work on this
            WithinRange = true;
        else
            WithinRange = false;


        if (CanHitAgain && WithinRange)
        {
            Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(MeleePos.position, AttackRange, WhatisHittable);
            for (int i = 0; i < enemiesToDamges.Length; i++)
            {
                Debug.Log("check this " + enemiesToDamges[i].gameObject.layer);
                if (enemiesToDamges[i].gameObject.layer == 7)
                {
                    Debug.Log("hi looooooooooooooooook");
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(MeleePos.position, AttackRange);
    }
}
