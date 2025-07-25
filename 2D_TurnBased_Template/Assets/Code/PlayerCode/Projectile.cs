using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectiles info")]
    public float SpeedOfProjectile;
    public float LifeTimeOfProjectile;
    public float DistanceOfProjectile;
    [Header("Damage")]
    public int RangeDamage;
    [Header("Layers")]
    public LayerMask Enemy;
    private void Start()
    {
        Invoke("DestroyProjectile", LifeTimeOfProjectile);
    }

    private void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up, DistanceOfProjectile, Enemy);
        if(hitinfo.collider != null)
        {
            if (hitinfo)
            {
                Debug.Log("eneny hit!");
                hitinfo.collider.GetComponent<BaseEnemy>().TakeDamage(RangeDamage);
            }
            DestroyProjectile();
        }
        
        transform.Translate(Vector2.up * SpeedOfProjectile * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
