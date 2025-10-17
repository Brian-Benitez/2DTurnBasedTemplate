using System.Collections;
using UnityEngine;

public class DKRangeAttack : State
{
    public Transform RangeAttackPos;
    public int DKRangeDamage;

    [Header("Enemys attack range and T.T.A")]
    public float RangeAttackRange;
    public float TimeBtwAttack;
    public float WindUpTimeForRange;

    [Header("Bools Conditions to attack")]
    public bool CanHitAgain = true;

    [Header("Layermasks for what can be hit")]
    public LayerMask WhatisHittable;


    DKChaseState dKChaseState;
    private void Start()
    {
        dKChaseState = GetComponentInParent<DKChaseState>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(CanHitAgain && dKChaseState.DistanceFromPlayer > 7f)
        {
            Debug.Log("jjooo");
            StartCoroutine(WindUpRangeAttack());
        }
    }

    void RangeAttack()
    {
        RangeAttackPos = NPCController.Instance.Player.transform;
        Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(RangeAttackPos.position, RangeAttackRange, WhatisHittable);
        /*
        if (enemiesToDamges.Length == 0)
        {
            Debug.Log("i hit no one:(");
            AttackMissedPlayer = true;
        }
        else
            AttackMissedPlayer = false;
        */
        for (int i = 0; i < enemiesToDamges.Length; i++)
        {
            enemiesToDamges[i].GetComponent<BaseCharacter>().TakeDamage(DKRangeDamage);
            Debug.Log("Enemy hit " + enemiesToDamges[i].gameObject.name + "for " + DKRangeDamage);
        }
    }

    public IEnumerator WindUpRangeAttack()
    {
        Debug.Log("Winding up attack " + WindUpTimeForRange + " Seconds");
        yield return new WaitForSeconds(WindUpTimeForRange);
        RangeAttack();
    }
    public override State RunCurrentState()
    {
        return this;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(RangeAttackPos.position, RangeAttackRange);
    }
}
