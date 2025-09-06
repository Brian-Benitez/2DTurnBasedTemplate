using System.Data.Common;
using UnityEngine;
using UnityEngine.Rendering;

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
                if (hitinfo.collider.gameObject.GetComponent<BaseCharacter>() != null)
                {
                    hitinfo.collider.GetComponent<BaseCharacter>().TakeDamage(RangeDamage);
                }
                else if (hitinfo.collider.gameObject.GetComponent<BaseEnemy>() != null)
                {
                    Debug.Log("loook");
                    hitinfo.collider.GetComponent<BaseEnemy>().TakeDamage(RangeDamage);
                }
                else if (hitinfo.collider.gameObject.CompareTag("Barricade"))
                {
                    Debug.Log("u hit barricade");
                    BarricadeController.Instance.BarricadeTakesDamage(RangeDamage);
                }
                    
                //if hit nothing, then check this bool and do something else!
            }
            DestroyProjectile();
        }
        else
        {
            Debug.Log("U hit nothinmg");
            DestroyProjectile();
        }

            transform.Translate(Vector2.up * SpeedOfProjectile * Time.deltaTime);
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
