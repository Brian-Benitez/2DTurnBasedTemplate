using UnityEngine;

public class PlayerRangeWeapon : MonoBehaviour
{
    public float Offset;
    public float TimeBtwAttack;

    public GameObject Projectile;
    public Transform ShotPoint;

    public bool CanRangeAttackAgain;

    private float _maxTimeBtwAttacks;

    private void Start() => _maxTimeBtwAttacks = TimeBtwAttack;


    private void Update()
    {
        //This deals with rotating weapon below
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + Offset);

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
