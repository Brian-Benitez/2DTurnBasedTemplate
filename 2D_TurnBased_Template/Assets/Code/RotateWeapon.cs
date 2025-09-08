using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    public Camera Camera;
    private Vector3 mousepos;

    // Update is called once per frame
    void Update()
    {
        //This deals with rotating weapon below
        mousepos = Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousepos - transform.position;
        float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotz);

    }
}
