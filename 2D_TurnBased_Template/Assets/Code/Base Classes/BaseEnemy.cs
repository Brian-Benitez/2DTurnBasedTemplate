using UnityEngine;
using DG.Tweening;

public class BaseEnemy : MonoBehaviour
{
    public int EnemyHealth;
    public int EnemySpeed;
    public int EnemyDamage;
    public float EnemyDamageRate;

    [SerializeField]
    public enum TypeOfEnemy
    {
        Swordsman, 
        Archer
    }

    public TypeOfEnemy EnemyType;

    public void TakeDamage(int  damage)
    {
        EnemyHealth -= damage;
        Debug.Log("enemy took: " + damage);
        DoesEnemyDie();
    }

    public void DoesEnemyDie()
    {
        if (EnemyHealth < 0)
        {
            this.gameObject.gameObject.SetActive(false);
        }
        else
            Debug.Log("has health stil");
    }
}
