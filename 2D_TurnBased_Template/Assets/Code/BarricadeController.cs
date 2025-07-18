using UnityEngine;

public class BarricadeController : MonoBehaviour
{
    public int BarricadeHealth;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))//im already checking layermasks, maybe i can do that here as well?
            BarricadeTakesDamage(GetComponent<EnemyController>().EnemyDamageOutput);// I dont like this tbh
    }


    void BarricadeTakesDamage(int damage)
    {
        BarricadeHealth -= damage;
        Debug.Log("barricade took damage!");
    }
}
