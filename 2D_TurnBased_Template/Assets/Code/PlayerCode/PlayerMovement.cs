using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;
    public GameObject PlayerObject;
    public Rigidbody2D Rb;

    public bool StopPlayerMovement = false;

    [Header("Dash Settings")]
    public float DashSpeed = 10f;
    public float DashDuration = 1f;
    public float DashCoolDown = 1f;
    public bool IsDashing;
    public bool CanDash = true;

    Vector2 moveDirection;
    Vector2 mousePosition;

    private void Update()
    {
        if (IsDashing)
            return;

        if(StopPlayerMovement)
            return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.LeftShift) && CanDash)
        {
            Debug.Log("dash");
            StartCoroutine(Dash());
        }
    }

    private void FixedUpdate()
    {
        if (IsDashing)
            return;

        Rb.linearVelocity  = new Vector2(moveDirection.x * PlayerSpeed, moveDirection.y * PlayerSpeed);
        //Vector2 aimdirection = mousePosition - Rb.position;
        //float aimAngle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg - 90f;
        //Rb.rotation = aimAngle;
    }

    public IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;
        Rb.linearVelocity = new Vector2(moveDirection.x * DashSpeed, moveDirection.y * DashSpeed);
        yield return new WaitForSeconds(DashDuration);
        IsDashing = false;  
        yield return new WaitForSeconds(DashCoolDown);
        CanDash = true;
    }

    public void TurnOnStopPlayerMovement() => StopPlayerMovement = true;

    public void TurnOffStopPlayerMovement() => StopPlayerMovement = false;
}
