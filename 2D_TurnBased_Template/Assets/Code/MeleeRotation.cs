using UnityEngine;

public class MeleeRotation : MonoBehaviour
{
    public Vector2 PointerPosition {  get; private set; }

    private void Update()
    {
        transform.right = (PointerPosition-(Vector2)transform.position).normalized;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        PointerPosition = mousePos;
    }
}
