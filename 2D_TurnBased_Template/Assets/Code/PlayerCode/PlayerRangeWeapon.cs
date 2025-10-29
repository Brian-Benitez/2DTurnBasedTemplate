using UnityEngine;
using UnityEngine.Rendering;

public class PlayerRangeWeapon : MonoBehaviour
{
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;

    public bool CanRangeAttackAgain;

    private float _maxTimeBtwAttacks;
    private PlayerMovement PlayerMovementRef;

    private void Start()
    {
        _maxTimeBtwAttacks = TimeBtwAttack;
        PlayerMovementRef = GetComponentInParent<PlayerMovement>();
    }


    private void Update()
    {
        if (PlayerMovementRef.IsDashing)
            return;

        if(Input.GetMouseButtonDown(0) && CanRangeAttackAgain)
        {
            Instantiate(Projectile, ShotPoint.position, transform.rotation);
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
