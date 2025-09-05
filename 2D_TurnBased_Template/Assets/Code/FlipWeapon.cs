using UnityEngine;
using UnityEngine.Rendering;

public class FlipWeapon : MonoBehaviour
{
    public Transform LeftsideWeaponPos;
    public Transform RightsideWeaponPos;
    public GameObject Weapon;
    public GameObject Target;

    TargetARangeEnemyState TargetARangeEnemyState;

    private void Start()
    {
        TargetARangeEnemyState = GetComponent<TargetARangeEnemyState>();
    }

    void Update()
    {
        Vector3 enemyDirectionLocal = TargetARangeEnemyState.CurrentRangeTarget.transform.InverseTransformPoint(this.transform.position);

        if (enemyDirectionLocal.x < 0)
        {
            Weapon.transform.position = RightsideWeaponPos.position;
        }
        else if(enemyDirectionLocal.x > 0)
        {
            Weapon.transform.position = LeftsideWeaponPos.position;
        }
           
    }
}
