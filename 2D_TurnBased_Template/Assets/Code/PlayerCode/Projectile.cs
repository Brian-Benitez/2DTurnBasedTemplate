using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Speed;
    public float LifeTime;
    public float Distance;
    public int RangeDamage;
    public LayerMask Enemy;
    private void Start()
    {
        Invoke("DestroyProjectile", LifeTime);
    }

    private void Update()
    {

        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, Distance);
        if(hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("eneny hit!");
                hitinfo.collider.GetComponent<EnemyController>().TakeDamage(RangeDamage);
            }
            DestroyProjectile();
        }
        
        transform.Translate(transform.up * Speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
