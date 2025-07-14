using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float StartTimeBtwAttack;

    public Transform AttackPos;
    public float AttackRange;
    public int PlayerDamage;
    public LayerMask WhatIsEnemies;
    public bool CanAttackAgain = false;
    public float _timeBtwAttack = 0;

    private void Update()//we need to make a timer for when you can attack again!
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("hi");
            Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);
            for (int i = 0; i < enemiesToDamges.Length; i++)
            {
                enemiesToDamges[i].GetComponent<EnemyController>().TakeDamage(PlayerDamage);
            }
        }
        else
        {
            //_timeBtwAttack -= Time.deltaTime;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange); 
    }
}
