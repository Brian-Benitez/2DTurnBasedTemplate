using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovementForEnemy : MonoBehaviour
{
    public List<GameObject> GoodguysGameObjects;
    public GameObject BarricadeGameObject;
    public Transform CurrentTarget;

    public float MovementSpeed;
    [SerializeField]
    private float _distance;
    private EnemyMeleeAttack enemyMeleeAttackRef;

    private void Start()
    {
        enemyMeleeAttackRef = GetComponentInChildren<EnemyMeleeAttack>();
    }
    void Update()
    {
        if(BarricadeController.Instance.BarricadeHealth > 0 && !enemyMeleeAttackRef.WithinRange)
            CurrentTarget = BarricadeGameObject.transform;
        else if(enemyMeleeAttackRef.WithinRange)
            return;


        _distance = Vector2.Distance(transform.position, CurrentTarget.transform.position);
        Vector2 direction = CurrentTarget.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, CurrentTarget.transform.position, MovementSpeed * Time.deltaTime);
    }
}
