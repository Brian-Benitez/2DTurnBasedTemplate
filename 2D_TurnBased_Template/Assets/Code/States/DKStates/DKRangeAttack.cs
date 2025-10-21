using System.Collections;
using UnityEngine;

public class DKRangeAttack : State
{
    [SerializeField]
    public GameObject RangeAttackPos;
    [SerializeField]
    public GameObject Player;
    public int DKRangeDamage;

    [Header("Enemys attack range and T.T.A")]
    public float RangeAttackRange;
    public float TimeBtwAttack;
    public float WindUpTimeForRange;

    [Header("Bools Conditions to attack")]
    public bool CanRangeAttack = false;
    public bool IsAttackingNow = false;

    [Header("Layermasks for what can be hit")]
    public LayerMask WhatisHittable;

    private float _maxTimeBtwAttacks;
    DKChaseState dKChaseState;
    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        dKChaseState = GetComponentInParent<DKChaseState>(); 
    }

    // Update is called once per frame
    void Update()
    {

        if (CanRangeAttack)
        {
            Debug.Log("jjooo");
            StartCoroutine(WindUpRangeAttack());
        }

        if (TimeBtwAttack <= 0 && !IsAttackingNow)
        {
            CanRangeAttack = true;
            return;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
            CanRangeAttack = false;
        }
    }

    void RangeAttack()
    {
        
        Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(RangeAttackPos.transform.position, RangeAttackRange, WhatisHittable);
        
        if (enemiesToDamges.Length == 0)
        {
            Debug.Log("i hit no one:(");
        }
        
        for (int i = 0; i < enemiesToDamges.Length; i++)
        {
            enemiesToDamges[i].GetComponent<BaseCharacter>().TakeDamage(DKRangeDamage);
            Debug.Log("Enemy hit " + enemiesToDamges[i].gameObject.name + "for " + DKRangeDamage);
        }

    }

    public IEnumerator WindUpRangeAttack()
    {
        Debug.Log("before");
        RangeAttackPos.transform.position = Player.transform.position;
        IsAttackingNow = true;
        Debug.Log("Winding up attack " + WindUpTimeForRange + " Seconds");
        yield return new WaitForSeconds(WindUpTimeForRange);
        RangeAttack();
        RestartTimerForRangeAttacks();
        IsAttackingNow = false;
    }
    void RestartTimerForRangeAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    public override State RunCurrentState()
    {
        if (!CanRangeAttack && !IsAttackingNow)
            return dKChaseState;

        return this;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(RangeAttackPos.transform.position, RangeAttackRange);
    }
}
