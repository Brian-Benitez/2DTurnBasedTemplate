using UnityEngine;

public class EnemyWeaponRotation : MonoBehaviour
{
    private Vector3 playerpos;
    TargetAEnemyState target;

    private void Start()
    {
        target = GetComponentInParent<TargetAEnemyState>();
    }
    // Update is called once per frame
    void Update()
    {
        //This deals with rotating weapon below
        playerpos = target.CurrentTargetPos.transform.position;
        Vector3 rotation = playerpos - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);
    }
}
