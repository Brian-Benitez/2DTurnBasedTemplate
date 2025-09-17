using UnityEngine;
using UnityEngine.Rendering;

public class FlipWeapon : MonoBehaviour
{
    public Transform LeftsideWeaponPos;
    public Transform RightsideWeaponPos;
    public GameObject Weapon;
    public GameObject Target;

    void Update()
    {
        Vector3 enemyDirectionLocal = NPCController.Instance.Player.transform.InverseTransformPoint(this.transform.position);

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
