using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class DKChaseState : State
{
    public DKRangeAttack rangeAttack;//fordemo 
    public AttackState AttackState;

    [Header("Floats")]
    public float MovementSpeed;
    public float MinimumDistanceFromPlayer;
    public float DistanceFromPlayer;
    public float PreferedRangeAttkDistance;

    public bool CanStartRangeAttack = false;

    private void Update()
    {
        if (rangeAttack.CanRangeAttack)
            return;

        //Debug.Log(DistanceFromPlayer = Vector2.Distance(transform.position, NPCController.Instance.Player.position));
        
        if(DistanceFromPlayer >= PreferedRangeAttkDistance && rangeAttack.CanRangeAttack)
            CanStartRangeAttack = true;  

        if (Vector2.Distance(transform.position, NPCController.Instance.Player.position) > MinimumDistanceFromPlayer)
        {
            AttackState.WithinRange = false;// not yet in range
            transform.position = Vector2.MoveTowards(transform.position, NPCController.Instance.Player.position, MovementSpeed * Time.deltaTime);
        }
        else
        {
            DistanceFromPlayer = Vector2.Distance(transform.position, NPCController.Instance.Player.position);
            AttackState.WithinRange = true;
        }
    }

    public override State RunCurrentState()
    {
        if (AttackState.WithinRange)
        return AttackState;

        if (CanStartRangeAttack)
            return rangeAttack;

        return this;
    }
}
