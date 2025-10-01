using UnityEngine;
using UnityEngine.Rendering;

public class PlayerRangeWeapon : MonoBehaviour
{
    public float Offset;
    public Quaternion Offsets;
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;

    public bool CanRangeAttackAgain;

    private float _maxTimeBtwAttacks;

    private void Start() => _maxTimeBtwAttacks = TimeBtwAttack;


    private void Update()
    {

        if(Input.GetMouseButtonDown(0) && CanRangeAttackAgain)
        {
            Instantiate(Projectile, ShotPoint.position, Offsets);
            RestartTimerForRangeAttacks();
        }

        if(TimeBtwAttack <= 0)
        {
            CanRangeAttackAgain = true;
            return;
        }
        else
        {
            TimeBtwAttack -= Time.deltaTime;
            CanRangeAttackAgain = false;
        }

    }

    void RestartTimerForRangeAttacks() => TimeBtwAttack = _maxTimeBtwAttacks;

}
