using System.Collections;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;
    public GameObject PlayerObject;
    public Rigidbody2D Rb;

    public bool StopPlayerMovement = false;

    [Header("Dash Settings")]
    public KeyCode DashInputKey;
    public float DashSpeed = 10f;
    public float DashDuration = 1f;
    public float DashCoolDown = 1f;
    public bool IsDashing;
    public bool CanDash = true;

    Vector2 moveDirection;
    Vector2 mousePosition;

    private void Update()
    {

        if(Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log("stop moving");
            moveDirection = Vector2.zero;
        }
            

        if (IsDashing || StopPlayerMovement)
            return;

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(DashInputKey) && CanDash)
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
