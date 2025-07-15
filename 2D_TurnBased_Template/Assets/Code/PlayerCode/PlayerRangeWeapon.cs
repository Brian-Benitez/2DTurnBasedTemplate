using UnityEngine;

public class PlayerRangeWeapon : MonoBehaviour
{
    public float Offset;

    public GameObject Projectile;
    public Transform ShotPoint;
    //Need to make time btw shots, copy from melee attacks
    private void Update()
    {
        //This deals with rotating weapon below
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(difference.x, difference.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + Offset);

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Projectile, ShotPoint.position, transform.rotation);
        }
    }


}
