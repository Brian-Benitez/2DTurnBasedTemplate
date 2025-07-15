using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    public float StartTimeBtwAttack;

    public Transform AttackPos;
    public float AttackRange;
    public int PlayerDamage;
    public LayerMask WhatIsEnemies;
    public bool CanAttackAgain = false;

    public float _timeBtwAttack;

    [SerializeField]
    private float _maxTimeBtwAttacks;

    private void Start()
    {
        _maxTimeBtwAttacks = _timeBtwAttack;
        RestartTimerForAttacks();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && CanAttackAgain)
        {
            Debug.Log("hi");
            Collider2D[] enemiesToDamges = Physics2D.OverlapCircleAll(AttackPos.position, AttackRange, WhatIsEnemies);
            for (int i = 0; i < enemiesToDamges.Length; i++)
            {
                enemiesToDamges[i].GetComponent<EnemyController>().TakeDamage(PlayerDamage);
            }
            RestartTimerForAttacks();
        }
        if(_timeBtwAttack <= 0f)
        {
            CanAttackAgain = true;
            return;
        }
        else
        {
            _timeBtwAttack -= Time.deltaTime;
            CanAttackAgain = false;
        }
            
    }
    void RestartTimerForAttacks() => _timeBtwAttack = _maxTimeBtwAttacks;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttackRange); 
    }
}
