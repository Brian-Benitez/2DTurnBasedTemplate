using UnityEngine;

public class EnemyController : MonoBehaviour// I need to make this better, theres gonna be diff types of enemys with diff stats!
{
    public int EnemyHealth;
    public int EnemySpeed;
    public int EnemyDamageOutput;

    public void TakeDamage(int damage)
    {
        EnemyHealth -= damage;
        Debug.Log("enemy took: " +  damage);
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

