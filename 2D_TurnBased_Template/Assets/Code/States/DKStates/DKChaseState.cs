using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class DKChaseState : State
{
    public DKRangeAttack rangeAttack;//fordemo 

    [Header("Floats")]
    public float MovementSpeed;
    public float MinimumDistance;
    public float DistanceFromPlayer;

    public bool IsTooFarAway = false;

    private void Update()
    {
        Debug.Log(DistanceFromPlayer = Vector2.Distance(transform.position, NPCController.Instance.Player.position));
        if(DistanceFromPlayer > 7f)
            IsTooFarAway = true;

        if (Vector2.Distance(transform.position, NPCController.Instance.Player.position) > MinimumDistance)
        {
            //AttackState.WithinRange = false;// not yet in range
            transform.position = Vector2.MoveTowards(transform.position, NPCController.Instance.Player.position, MovementSpeed * Time.deltaTime);
        }
        else
        {
            DistanceFromPlayer = Vector2.Distance(transform.position, NPCController.Instance.Player.position);
            //AttackState.WithinRange = true;
        }
    }

    public override State RunCurrentState()
    {
        //if (AttackState.WithinRange)
        //return AttackState;
        if (IsTooFarAway)
            return rangeAttack;

        return this;
    }
}
