using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [Header("Transforms")]
    public Transform AttackPos;

    [Header("Floats")]
    public float AttackRange;
    public float TimeBtwAttack;

    [Header("Ints")]
    public int PlayerDamage;

    [Header("LayerMasks")]
    public LayerMask WhatIsEnemies;

    [Header("Booleans")]
    public bool CanMeleeAttackAgain = false;

    //[SerializeField]
    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        RestartTimerForAttacks();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && CanMeleeAttackAgain)
        {
            Debug.Log("hi");
            Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);
            for (int i = 0; i < enemiesToDamges.Length; i++)
            {
                enemiesToDamges[i].GetComponent<EnemyController>().TakeDamage(PlayerDamage);
            }
            RestartTimerForAttacks();
        }
        if(TimeBtwAttack <= 0f)
        {
            CanMeleeAttackAgain = true;
            return;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
            CanMeleeAttackAgain = false;
        }
            
    }
    void RestartTimerForAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange); 
    }
}
