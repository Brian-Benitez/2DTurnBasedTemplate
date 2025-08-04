using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Rendering;

public class MovementForEnemy : MonoBehaviour
{
    public List<GameObject> GoodguysGameObjects;
    public GameObject BarricadeGameObject;
    public Transform CurrentTarget;//keep this public until im done with it fully

    public float MovementSpeed;

    public float _distanceFromTarget;//debuging keep it public
    private EnemyMeleeAttack enemyMeleeAttackRef;

    private void Start()
    {
        enemyMeleeAttackRef = GetComponentInChildren<EnemyMeleeAttack>();
    }
    void Update()
    {
        if(BarricadeController.Instance.BarricadeHealth > 0 && !enemyMeleeAttackRef.WithinRange)
            CurrentTarget = BarricadeGameObject.transform;//We need to make a state controller for enemys + add attacking to it
        else if (enemyMeleeAttackRef.WithinRange)
            return;


        _distanceFromTarget = Vector2.Distance(transform.position, CurrentTarget.transform.position);
        Vector2 direction = CurrentTarget.transform.position - transform.position;
        transform.position = Vector2.MoveTowards(this.transform.position, CurrentTarget.transform.position, MovementSpeed * Time.deltaTime);
    }
}
