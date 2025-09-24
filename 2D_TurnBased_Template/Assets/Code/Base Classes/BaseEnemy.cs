using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;

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
            //this.gameObject.gameObject.SetActive(false);
            Debug.Log("im dead");
            EnemysManager.Instance.AmountOfEnemies = -1;
            Destroy(this.gameObject);
        }
        else
            Debug.Log("has health stil");
    }
}
