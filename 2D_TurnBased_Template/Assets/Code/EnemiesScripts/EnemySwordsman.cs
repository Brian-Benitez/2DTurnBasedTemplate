using UnityEngine;

public class EnemySwordsman : BaseEnemy
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Barricade"))
        {
            Delay(EnemyDamageRate, () =>
            {
                BarricadeController.Instance.BarricadeTakesDamage(EnemyDamage);
                Debug.Log("did damage!");
            });
        }
    }
}
