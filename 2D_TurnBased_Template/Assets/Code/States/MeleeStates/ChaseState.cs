using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [Header("States")]
    AttackState AttackState;

    [Header("Floats")]
    public float MovementSpeed;
    public float MinimumDistance;
    public float DistanceFromPlayer;

    private void Start()
    {
        AttackState = GetComponentInChildren<AttackState>();  
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, NPCController.Instance.Player.position) > MinimumDistance)
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

        return this;
    }
}
