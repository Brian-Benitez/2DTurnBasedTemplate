using UnityEngine;
using UnityEngine.Rendering;

public class EnemyMeleeAttack : MonoBehaviour
{
    public Transform MeleePos;

    public float AttackRange;
    public float TimeBtwAttack;

    public bool CanHitAgain = true;

    public LayerMask WhatisHittable;

    private EnemySwordsman EnemySwordsmanRef;
    private float _maxTimeBtwAttacks;

    private void Start()
    {
        EnemySwordsmanRef = gameObject.GetComponentInParent<EnemySwordsman>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Barricade") || collision.CompareTag("NPC"))//not great but need to check
        {
            if (CanHitAgain)
            {
                Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(MeleePos.position, AttackRange, WhatisHittable);
                for (int i = 0; i < enemiesToDamges.Length; i++)
                {
                    enemiesToDamges[i].GetComponent<BaseCharacter>().TakeDamage(EnemySwordsmanRef.EnemyDamage);
                }
                Debug.Log("hit player for: " + EnemySwordsmanRef.EnemyDamage);
            }
        }
    }

    void Update()
    {
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
