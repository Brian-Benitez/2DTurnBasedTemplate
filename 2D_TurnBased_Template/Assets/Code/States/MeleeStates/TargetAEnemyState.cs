
using System.Collections.Generic;
using UnityEngine;

public class TargetAEnemyState : State
{
    [Header("State")]
    ChaseState ChaseState;
    [Header("Bool")]
    public bool HaveATarget = false;
    [Header("Current obj target")]
    public GameObject CurrentTargetPos;

    private void Start()
    {
        ChaseState = GetComponent<ChaseState>();
    }

    public override State RunCurrentState()
    {   
        if(HaveATarget)
            return ChaseState;

        else if(!HaveATarget)
        {
            //CurrentTargetPos = NPCController.Instance.Player;
            //ChaseState.RestartDistance();
            TurnOnHaveATarget();
        }
        return this;
    }
    public void TurnOnHaveATarget() => HaveATarget = true;
    public void TurnOffBoolHaveATarget () => HaveATarget = false;

}
